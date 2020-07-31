using ImmersiveMiracast.Core;
using ImmersiveMiracast.Util;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ImmersiveMiracast
{
    /// <summary>
    /// Contains launch logic of the app
    /// </summary>
    public static class App
    {
        /// <summary>
        /// app should not close, but instead restart itself
        /// </summary>
        public static bool shouldRestartApp;

        /// <summary>
        /// Application config
        /// </summary>
        public static AppConfig Config { get; private set; }

        /// <summary>
        /// main app instance
        /// </summary>
        public static CastApp AppInstance { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            //forms stuff
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            //reset config on launch with -resetConfig flag
            foreach (string arg in args)
            {
                if (arg.Equals("-resetConfig", StringComparison.OrdinalIgnoreCase))
                    new AppConfig().ToFile(GetConfigFile());
            }

            do
            {
                //reset restart flag
                shouldRestartApp = false;

                //(re)load config
                LoadConfig();

                //enable / disable autostart
                Win32Util.RegisterAutostart(Config.Strings.AppName, GetLaunchCommand(), Config.ShouldAppAutostart);

                //start app
                AppInstance = new CastApp();
                Application.Run(AppInstance);
            } while (shouldRestartApp);
        }

        /// <summary>
        /// load the config into App.Config
        /// </summary>
        static void LoadConfig()
        {
            //load from file
            Config = AppConfig.FromFile(GetConfigFile());

            //rewrite config file (in case config layout changed, to add the missing keys)
            Config.ToFile(GetConfigFile());
        }

        /// <summary>
        /// get the config path for the current user
        /// </summary>
        /// <returns>path to config file</returns>
        public static string GetConfigFile()
        {
            //return Path.Combine(Application.LocalUserAppDataPath, "config.xml");
            string cfgDir = Path.Combine(Directory.GetParent(Application.LocalUserAppDataPath).FullName, "config.xml");
            Directory.CreateDirectory(Path.GetDirectoryName(cfgDir));
            return cfgDir;
        }

        /// <summary>
        /// Get the launch command for the app
        /// </summary>
        /// <returns>the launch command</returns>
        public static string GetLaunchCommand()
        {
            //get path for current assembly
            string cmdLine = Assembly.GetExecutingAssembly().Location;

            //fix for dotnet running in .dll files
            if (Path.GetExtension(cmdLine).Equals(".dll", StringComparison.OrdinalIgnoreCase))
            {
                //get exe instead of dll
                cmdLine = Path.Combine(Path.GetDirectoryName(cmdLine), Path.GetFileNameWithoutExtension(cmdLine) + ".exe");
            }

            return cmdLine;
        }
    }
}
