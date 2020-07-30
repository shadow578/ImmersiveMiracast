using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ImmersiveMiracast.Util
{
    /// <summary>
    /// contains the application configuration
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Display name of the miracast sink
        /// {MACHINE_NAME} will be replaced with actual name of the machine
        /// </summary>
        public string CastDisplayName { get; set; } = "ImmersiveCast on {MACHINE_NAME}";

        /// <summary>
        /// command to use when using "configure" option
        /// </summary>
        public string ConfigureCommand { get; set; } = "notepad";

        /// <summary>
        /// should the app auto- start with the current user?
        /// </summary>
        public bool ShouldAppAutostart { get; set; } = false;

        /// <summary>
        /// strings used in the app
        /// </summary>
        public AppStrings Strings { get; set; } = new AppStrings();

        /// <summary>
        /// deserialize a file to a new instance
        /// </summary>
        /// <param name="path">the file to deserialize</param>
        /// <returns>the object (either deserialized or default)</returns>
        public static AppConfig FromFile(string path)
        {
            //check file existts
            if (!File.Exists(path))
            {
                AppConfig cfg = new AppConfig();
                cfg.ToFile(path);
                return cfg;
            }

            //deserialize
            XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
            using (XmlReader reader = XmlReader.Create(path))
            {
                AppConfig cfg = serializer.Deserialize(reader) as AppConfig;
                if (cfg == null)
                    cfg = new AppConfig();
                return cfg;
            }
        }

        /// <summary>
        /// serialize to a file
        /// </summary>
        /// <param name="path">the path to save to</param>
        public void ToFile(string path)
        {
            //create dir if needed
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            //serialize
            XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
            using (StreamWriter writer = File.CreateText(path))
            using (XmlWriter xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings()
            {
                Indent = true
            }))
            {
                serializer.Serialize(xmlWriter, this);
            }
        }
    }

    /// <summary>
    /// contains application strings
    /// </summary>
    public class AppStrings
    {
        /// <summary>
        /// name of the app, used in ui
        /// </summary>
        public string AppName { get; set; } = "ImmersiveCast";

        /// <summary>
        /// Application is ready to receive
        /// 0 = castReceiver.GetCurrentSettings().FriendlyName; = display name of the receiver
        /// </summary>
        public string CastReady { get; set; } = "All set!\nConnect to \"{0}\" to begin casting.";

        /// <summary>
        /// miracast is not supported on the device
        /// </summary>
        public string CastNotSupported { get; set; } = "Miracast is not supported by this device!\nApplication will now terminate.";

        /// <summary>
        /// unknown error while initializing miracast
        /// </summary>
        public string CastUnknownError { get; set; } = "A unknown error occured while starting the Miracast sink.\nApplication will now terminate.";

        /// <summary>
        /// a new connection was made with the receiver
        /// 0 = currentConnection.Transmitter.Name; = Display name of the transmitter
        /// </summary>
        public string CastWelcome { get; set; } = "{0} now shares their screen.";

        /// <summary>
        /// text body for configuration reset confirmation dialog
        /// </summary>
        public string ResetConfigConfirmation { get; set; } = "Are you sure you want to reset the configuration?";

        /// <summary>
        /// tray "reset configuration" option
        /// </summary>
        public string TrayResetConfig { get; set; } = "Reset Configuration";

        /// <summary>
        /// tray "configure" option
        /// </summary>
        public string TrayConfigure { get; set; } = "Configure";

        /// <summary>
        /// tray "restart session" option
        /// </summary>
        public string TrayRestartSession { get; set; } = "Restart Session";

        /// <summary>
        /// tray "restart app" option
        /// </summary>
        public string TrayRestartApp { get; set; } = "Restart App";

        /// <summary>
        /// tray "exit" option
        /// </summary>
        public string TrayExitApp { get; set; } = "Exit App";
    }
}
