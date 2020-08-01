using System;
using Windows.Media.Miracast;
using UWPMediaPlayer = Windows.Media.Playback.MediaPlayer;

namespace ImmersiveMiracast.Core
{
    /// <summary>
    /// Wraps the UWP MiracastReceiver from Microsoft.Toolkit into a more easy fire & forget system
    /// </summary>
    public class MiracastReceiverWrapper : IDisposable
    {
        /// <summary>
        /// results for StartSession()
        /// </summary>
        public enum SessionStartResult
        {
            /// <summary>
            /// session was started without problems
            /// </summary>
            Success,

            /// <summary>
            /// session init failed. no new session was created.
            /// </summary>
            Failure,

            /// <summary>
            /// miracast is not supported on this device. no new session was created.
            /// </summary>
            MiracastNotSupported
        }

        /// <summary>
        /// current miracast receiver
        /// </summary>
        MiracastReceiver castReceiver;

        /// <summary>
        /// current miracast session
        /// </summary>
        MiracastReceiverSession currentSession;

        /// <summary>
        /// player that plays back the miracast stream
        /// </summary>
        UWPMediaPlayer currentPlayer;

        /// <summary>
        /// internal version of DisplayName propertie, shortened to 50 characters
        /// </summary>
        string displayNameInt = "MiracastReceiver";

        #region Events
        /// <summary>
        /// called when a new pin is available. Show this pin somewhere in your ui, and only hide it when either CastStart or CastEnd have been called.
        /// only called when RequirePinAuth is set to true.
        /// </summary>
        public event Action<string /*transmitterName*/, string /*pin*/> PinAvailable;

        /// <summary>
        /// called when a new cast session starts, and the media source was created and is ready. 
        /// note that this is called before playback is started.
        /// </summary>
        public event Action<string /*transmitterName*/, UWPMediaPlayer /*castPlayer*/> CastStart;

        /// <summary>
        /// called when the current cast session ends (Disconnect or EndCastSession())
        /// </summary>
        public event Action CastEnd;

        /// <summary>
        /// called when a (debug) log should be written
        /// </summary>
        public event Action<string/*line*/> WriteLog;
        #endregion

        #region Properties
        /// <summary>
        /// name to display on other devices. max. 50 characters long
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (displayNameInt.Length > 50)
                    displayNameInt = displayNameInt.Substring(0, 50);
                return displayNameInt;
            }
            set
            {
                string name = value;
                if (name.Length > 50)
                    name = name.Substring(0, 50);

                displayNameInt = name;
            }
        }

        /// <summary>
        /// should a new session be automatically created when the current one disconnects?
        /// </summary>
        public bool AutoStartNewSession { get; set; } = true;

        /// <summary>
        /// is entering a pin required to connect?
        /// make sure you handle PinAvailable event if you enable this!
        /// </summary>
        public bool RequirePinAuth { get; set; } = false;

        /// <summary>
        /// get the currently active cast connection. If no connection is active, null is returned.
        /// </summary>
        public MiracastReceiverConnection CurrentConnection { get; private set; }
        #endregion

        #region Interface Methods
        /// <summary>
        /// init the miracast receiver. 
        /// call this before calling StartSession()
        /// </summary>
        public void InitReceiver()
        {
            //init receiver
            Log("start initializing receiver");
            castReceiver = new MiracastReceiver();
            castReceiver.StatusChanged += OnReceiverStatusChanged;

            //apply settings
            castReceiver.DisconnectAllAndApplySettings(GetReceiverSettings(castReceiver));
        }

        /// <summary>
        /// ends the old cast session and starts a new one
        /// </summary>
        public SessionStartResult StartNewSession()
        {
            //check receiver was initialized
            if (castReceiver == null)
                throw new InvalidOperationException("Miracast receiver was not yet initialized! Call InitReceiver first.");

            //end old cast session
            if (currentSession != null)
                EndCurrentSession(true);

            //init cast session, allow takeover
            currentSession = castReceiver.CreateSession(/*MainView*/null);
            currentSession.AllowConnectionTakeover = true;
            currentSession.MaxSimultaneousConnections = 1;

            //register event
            currentSession.ConnectionCreated += OnSessionConnectionCreated;
            currentSession.MediaSourceCreated += OnSessionMediaSourceCreated;
            currentSession.Disconnected += OnSessionDisconnect;

            //start receive on session
            MiracastReceiverSessionStartResult startResult = currentSession.Start();
            Log($"new miracast session initialized. result: {startResult.Status} ({(startResult.ExtendedError == null ? "No Error" : startResult.ExtendedError.ToString())})");

            //return correct result, end session if init failed
            switch (startResult.Status)
            {
                case MiracastReceiverSessionStartStatus.Success:
                    return SessionStartResult.Success;
                case MiracastReceiverSessionStartStatus.MiracastNotSupported:
                    EndCurrentSession(false);
                    return SessionStartResult.MiracastNotSupported;
                case MiracastReceiverSessionStartStatus.AccessDenied:
                case MiracastReceiverSessionStartStatus.UnknownFailure:
                default:
                    EndCurrentSession(false);
                    return SessionStartResult.Failure;
            }
        }

        /// <summary>
        /// end the current cast session
        /// </summary>
        public void EndCastSession()
        {
            EndCurrentSession(true);
        }

        /// <summary>
        /// end the current session and dispose the receiver
        /// </summary>
        public void Dispose()
        {
            //end session
            EndCurrentSession(false);

            //disable receiver
            castReceiver = null;
        }
        #endregion

        #region Receiver Events
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

            if (AutoStartNewSession)
                StartNewSession();
        }

        /// <summary>
        /// a new connection was created
        /// </summary>
        void OnSessionConnectionCreated(MiracastReceiverSession sender, MiracastReceiverConnectionCreatedEventArgs args)
        {
            //configure connection
            CurrentConnection = args.Connection;
            CurrentConnection.InputDevices.Keyboard.TransmitInput = false;

            //send pin event
            if (!string.IsNullOrWhiteSpace(args.Pin))
                PinAvailable?.Invoke(CurrentConnection.Transmitter.Name, args.Pin);

            //log details
            Log($"new connection created with {CurrentConnection.Transmitter.Name} ({CurrentConnection.Transmitter.MacAddress}). Auth pin is {(string.IsNullOrWhiteSpace(args.Pin) ? "No Pin" : args.Pin)}");
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
            CastStart?.Invoke(CurrentConnection.Transmitter.Name, currentPlayer);

            //start playback
            Log($"starting playback of {CurrentConnection.Transmitter.Name} ({CurrentConnection.Transmitter.MacAddress})");
            currentPlayer.Play();
        }
        #endregion

        /// <summary>
        /// initialize settings for the miracast receiver
        /// </summary>
        /// <param name="receiver">the receiver to get settings for</param>
        /// <returns>initialized settings</returns>
        MiracastReceiverSettings GetReceiverSettings(MiracastReceiver receiver)
        {
            MiracastReceiverSettings s = receiver.GetDefaultSettings();
            s.AuthorizationMethod = RequirePinAuth ? MiracastReceiverAuthorizationMethod.PinDisplayRequired : MiracastReceiverAuthorizationMethod.None;
            s.FriendlyName = DisplayName;
            return s;
        }

        /// <summary>
        /// end the current cast session, and call CastEnd event
        /// </summary>
        /// <param name="sendEvent">should CastEnd be called?</param>
        void EndCurrentSession(bool sendEvent)
        {
            CurrentConnection?.Disconnect(MiracastReceiverDisconnectReason.Finished);
            CurrentConnection = null;

            currentSession?.Dispose();
            currentSession = null;

            currentPlayer?.Dispose();
            currentPlayer = null;

            if (sendEvent)
                CastEnd?.Invoke();
        }

        /// <summary>
        /// write a debugging string
        /// </summary>
        /// <param name="s">the string to log</param>
        void Log(string s)
        {
            WriteLog?.Invoke(s);
        }
    }
}
