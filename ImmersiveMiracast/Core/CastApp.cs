using ImmersiveMiracast.UI;
using ImmersiveMiracast.Util;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;
using Windows.Media.Miracast;
using UWPMediaPlayer = Windows.Media.Playback.MediaPlayer;

namespace ImmersiveMiracast.Core
{
    /// <summary>
    /// main logic of the app
    /// </summary>
    public class CastApp : ApplicationContext
    {
        /// <summary>
        /// local reference to Application strings
        /// </summary>
        AppStrings S
        {
            get
            {
                return App.Config.Strings;
            }
        }

        /// <summary>
        /// tray icon ui of the app
        /// </summary>
        TrayUI trayUI;

        /// <summary>
        /// current instance of the cast ui
        /// </summary>
        ImmersiveCastUI castUI;

        #region Miracast runtime vars
        /// <summary>
        /// current miracast receiver
        /// </summary>
        MiracastReceiver castReceiver;

        /// <summary>
        /// current miracast session
        /// </summary>
        MiracastReceiverSession currentSession;

        /// <summary>
        /// current miracast connection
        /// </summary>
        MiracastReceiverConnection currentConnection;

        /// <summary>
        /// player that plays back the miracast stream
        /// </summary>
        UWPMediaPlayer currentPlayer;
        #endregion

        /// <summary>
        /// is the application shutting down?
        /// </summary>
        bool isShuttingDown = false;

        public CastApp()
        {
            //register application exit
            Application.ApplicationExit += OnAppExit;

            //dispatch init
            Dispatcher.CurrentDispatcher.BeginInvoke(() =>
            {
                InitTray();
                InitReceiver();
            });
        }

        /// <summary>
        /// initialize the tray icon
        /// </summary>
        void InitTray()
        {
            //init tray icon
            trayUI = new TrayUI();
            trayUI.Init(S.AppName, SharedResources.app_icon);

            //add menu options
            trayUI.AddMenuItem(S.TrayResetConfig, (s, e) =>
            {
                Log("USER: reset config");
                if (MessageBox.Show(S.AppName, S.ResetConfigConfirmation, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                //user is ok with config reset, do it
                new AppConfig().ToFile(App.GetConfigFile());
                App.shouldRestartApp = true;
                Application.Exit();
            });
            trayUI.AddMenuItem(S.TrayConfigure, (s, e) =>
            {
                Log("USER: open config");
                Process.Start(App.Config.ConfigureCommand, App.GetConfigFile());
            });
            trayUI.AddMenuItem(S.TrayRestartSession, (s, e) =>
            {
                Log("USER: restart session");
                StartNewSession();
            });
            trayUI.AddMenuItem(S.TrayRestartApp, (s, e) =>
            {
                Log("USER: restart application");
                App.shouldRestartApp = true;
                Application.Exit();
            });
            trayUI.AddMenuItem(S.TrayExitApp, (s, e) =>
            {
                Log("USER: exit application");
                App.shouldRestartApp = false;
                Application.Exit();
            });
        }

        /// <summary>
        /// init and start the miracast receiver
        /// </summary>
        void InitReceiver()
        {
            //init receiver
            Log("start initializing receiver");
            castReceiver = new MiracastReceiver();
            castReceiver.StatusChanged += OnReceiverStatusChanged;

            //apply settings
            string name = App.Config.CastDisplayName.Replace("{MACHINE_NAME}", Environment.MachineName);
            if (name.Length > 50)
                name = name.Substring(0, 50);

            castReceiver.DisconnectAllAndApplySettings(GetReceiverSettings(castReceiver, name));

            //start a session
            StartNewSession();
        }

        /// <summary>
        /// Cast playback started
        /// </summary>
        /// <param name="player">player that plays the cast stream</param>
        void OnCastStart(UWPMediaPlayer player)
        {
            //show info
            Log("cast playback started");
            ShowToast(S.AppName, S.CastWelcome.Format(currentConnection.Transmitter.Name));

            //init and show cast ui
            castUI = new ImmersiveCastUI(S.AppName, player);
            castUI.KeyDown += (s, e) =>
            {
                //end session with ESC
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    EndCastSession();
                }
            };
            castUI.Show();
        }

        /// <summary>
        /// Cast playback ended
        /// </summary>
        void OnCastEnd()
        {
            //show info
            Log("cast playback ended");

            //close cast ui
            castUI?.Close();
            castUI = null;
        }

        /// <summary>
        /// the app exits
        /// </summary>
        void OnAppExit(object sender, EventArgs e)
        {
            //dispose of tray ui
            trayUI.Dispose();

            //end current session
            isShuttingDown = true;
            EndCastSession();
        }

        #region Miracast Events
        /// <summary>
        /// The status of the cast receiver changed
        /// </summary>
        void OnReceiverStatusChanged(MiracastReceiver sender, object args)
        {
            Log($"receiver listening status changed to {sender.GetStatus().ListeningStatus}");
        }

        /// <summary>
        /// the current session disconnected
        /// </summary>
        void OnSessionDisconnect(MiracastReceiverSession sender, MiracastReceiverDisconnectedEventArgs args)
        {
            Log("current session disconnected, creating new session...");
            StartNewSession();
        }

        /// <summary>
        /// a new connection was created
        /// </summary>
        void OnSessionConnectionCreated(MiracastReceiverSession sender, MiracastReceiverConnectionCreatedEventArgs args)
        {
            //configure connection
            currentConnection = args.Connection;
            currentConnection.InputDevices.Keyboard.TransmitInput = false;

            Log($"new connection created with {currentConnection.Transmitter.Name} ({currentConnection.Transmitter.MacAddress})");
        }

        /// <summary>
        /// a media source was created for the current session (start rendering to ui)
        /// </summary>
        void OnSessionMediaSourceCreated(MiracastReceiverSession sender, MiracastReceiverMediaSourceCreatedEventArgs args)
        {
            //init mediaplayer
            currentPlayer = new UWPMediaPlayer()
            {
                Source = args.MediaSource,
                IsVideoFrameServerEnabled = false,
                AutoPlay = true,
                RealTimePlayback = true
            };

            //call event
            OnCastStart(currentPlayer);

            //start playback
            Log($"starting playback of {currentConnection.Transmitter.Name} ({currentConnection.Transmitter.MacAddress})");
            currentPlayer.Play();
        }
        #endregion

        #region Cast Util
        /// <summary>
        /// ends the old cast session and starts a new one
        /// </summary>
        void StartNewSession()
        {
            //end old cast session
            EndCastSession();

            //abort if shutting down
            if (isShuttingDown) return;

            //init cast session, allow takeover
            currentSession = castReceiver.CreateSession(/*MainView*/null);
            currentSession.AllowConnectionTakeover = true;

            //register event
            currentSession.ConnectionCreated += OnSessionConnectionCreated;
            currentSession.MediaSourceCreated += OnSessionMediaSourceCreated;
            currentSession.Disconnected += OnSessionDisconnect;

            //start receive on session
            MiracastReceiverSessionStartResult startResult = currentSession.Start();
            Log($"new miracast session initialized. result: {startResult.Status}");

            //show error when start failed
            switch (startResult.Status)
            {
                case MiracastReceiverSessionStartStatus.Success:
                    Log("miracast init finished without error");
                    ShowToast(S.AppName, S.CastReady.Format(castReceiver.GetCurrentSettings().FriendlyName));
                    break;
                case MiracastReceiverSessionStartStatus.MiracastNotSupported:
                    Log("miracast is not supported on this device");
                    ShowErrorDialog(S.AppName, S.CastNotSupported);
                    Application.Exit();
                    break;
                case MiracastReceiverSessionStartStatus.AccessDenied:
                case MiracastReceiverSessionStartStatus.UnknownFailure:
                default:
                    Log($"unknown error while starting miracast: {startResult.Status} - {startResult.ExtendedError.ToString()}");
                    ShowErrorDialog(S.AppName, S.CastUnknownError);
                    Application.Exit();
                    break;
            }
        }

        /// <summary>
        /// end the current cast session
        /// </summary>
        void EndCastSession()
        {
            OnCastEnd();

            currentConnection?.Disconnect(MiracastReceiverDisconnectReason.Finished);
            currentConnection = null;

            currentSession?.Dispose();
            currentSession = null;

            currentPlayer?.Dispose();
            currentPlayer = null;
        }

        /// <summary>
        /// initialize settings for the miracast receiver
        /// </summary>
        /// <param name="receiver">the receiver to get settings for</param>
        /// <param name="displayName">displayname to use for the receiver</param>
        /// <returns>initialized settings</returns>
        MiracastReceiverSettings GetReceiverSettings(MiracastReceiver receiver, string displayName)
        {
            MiracastReceiverSettings s = receiver.GetDefaultSettings();
            s.AuthorizationMethod = MiracastReceiverAuthorizationMethod.None;
            s.FriendlyName = displayName;
            return s;
        }
        #endregion

        #region UI Util
        /// <summary>
        /// show a error dialog (message box)
        /// </summary>
        /// <param name="title">the title of the dialog</param>
        /// <param name="text">the error text</param>
        void ShowErrorDialog(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// show a toast message
        /// </summary>
        /// <param name="title">the title of the toast</param>
        /// <param name="text">the text bodx of the toast</param>
        void ShowToast(string title, string text)
        {
            trayUI?.ShowToast(title, text);
        }

        /// <summary>
        /// write a debugging string
        /// </summary>
        /// <param name="s">the string to log</param>
        void Log(string s)
        {
            Debug.WriteLine(s);
        }
        #endregion
    }
}
