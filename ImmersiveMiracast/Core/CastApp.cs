using ImmersiveMiracast.UI;
using ImmersiveMiracast.Util;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;
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
        /// miracast receiver to listen for, manage and render miracast connections
        /// </summary>
        MiracastReceiverWrapper miracastReceiver;

        /// <summary>
        /// tray icon ui of the app
        /// </summary>
        TrayUI trayUI;

        /// <summary>
        /// current instance of the cast ui
        /// </summary>
        ImmersiveCastUI castUI;

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
        /// initializes the receiver wrapper
        /// </summary>
        void InitReceiver()
        {
            //init receiver
            string name = App.Config.CastDisplayName.Replace("{MACHINE_NAME}", Environment.MachineName);
            miracastReceiver = new MiracastReceiverWrapper()
            {
                DisplayName = name,
                AutoStartNewSession = true
            };

            //register events
            miracastReceiver.CastStart += OnCastStart;
            miracastReceiver.CastEnd += OnCastEnd;
            miracastReceiver.WriteLog += Log;

            //init receiver and start first session
            miracastReceiver.InitReceiver();
            switch (miracastReceiver.StartNewSession())
            {
                case MiracastReceiverWrapper.SessionStartResult.Success:
                    Log("miracast init finished without error");
                    ShowToast(S.AppName, S.CastReady.Format(miracastReceiver.DisplayName));
                    break;

                case MiracastReceiverWrapper.SessionStartResult.MiracastNotSupported:
                    Log("miracast is not supported on this device");
                    ShowErrorDialog(S.AppName, S.CastNotSupported);
                    Application.Exit();
                    break;

                case MiracastReceiverWrapper.SessionStartResult.Failure:
                default:
                    Log($"unknown error while starting miracast");
                    ShowErrorDialog(S.AppName, S.CastUnknownError);
                    Application.Exit();
                    break;

            }
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
                miracastReceiver.StartNewSession();
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

        #region Events
        /// <summary>
        /// the app exits
        /// </summary>
        void OnAppExit(object sender, EventArgs e)
        {
            //dispose of tray ui
            trayUI.Dispose();

            //end current session
            miracastReceiver.AutoStartNewSession = false;
            miracastReceiver.EndCastSession();
        }

        /// <summary>
        /// called when a new cast session starts, and the media source was created and is ready. 
        /// note that this is called before playback is started.
        /// </summary>
        /// <param name="transmitterName">display name of the transmitter</param>
        /// <param name="castPlayer">player that plays the cast stream</param>
        void OnCastStart(string transmitterName, UWPMediaPlayer castPlayer)
        {
            //show info
            Log("cast playback started");
            ShowToast(S.AppName, S.CastWelcome.Format(transmitterName));

            //init and show cast ui
            if (App.Config.CastDisplayId < 0)
                //primary screen
                castUI = new ImmersiveCastUI(S.AppName, castPlayer);
            else
                //selected screen
                castUI = new ImmersiveCastUI(S.AppName, castPlayer, App.Config.CastDisplayId);
            castUI.KeyPreview = true;
            castUI.PreviewKeyDown += (s, e) =>
            {
                //end session with ESC
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    miracastReceiver.EndCastSession();
                }
            };
            castUI.Show();
        }

        /// <summary>
        /// called when the current cast session ends (Disconnect or EndCastSession())
        /// </summary>
        void OnCastEnd()
        {
            //show info
            Log("cast playback ended");

            //close cast ui
            castUI?.Close();
            castUI = null;
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
