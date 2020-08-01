using ImmersiveMiracast.Core;
using ImmersiveMiracast.Util;
using System;
using System.Diagnostics;
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
        /// main app instance
        /// </summary>
        public static CastApp AppInstance { get; private set; }

        /// <summary>
        /// Application config
        /// </summary>
        public static AppConfig Config { get; private set; }

        /// <summary>
        /// path to the config file for the current user
        /// </summary>
        public static string ConfigFile
        {
            get
            {
                //return Path.Combine(Application.LocalUserAppDataPath, "config.xml");
                string cfgDir = Path.Combine(Directory.GetParent(Application.LocalUserAppDataPath).FullName, "config.xml");
                Directory.CreateDirectory(Path.GetDirectoryName(cfgDir));
                return cfgDir;
            }
        }

        /// <summary>
        /// Get the launch command for the app
        /// </summary>
        public static string LaunchCommand
        {
            get
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

        /// <summary>
        /// app should not close, but instead restart itself
        /// </summary>
        public static bool ShouldRestartApp { get; set; }

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
                    new AppConfig().ToFile(ConfigFile);
            }

            do
            {
                //reset restart flag
                ShouldRestartApp = false;

                //(re)load config
                LoadConfig();

                //kill cast server
                if (Config.KillStrayCastServer)
                    TryKillCastServer();

                //enable / disable autostart
                Win32Util.RegisterAutostart(Config.Strings.AppName, LaunchCommand, Config.ShouldAppAutostart);

                //start app
                AppInstance = new CastApp();
                Application.Run(AppInstance);
            } while (ShouldRestartApp);
        }

        /// <summary>
        /// load the config into App.Config
        /// </summary>
        static void LoadConfig()
        {
            //load from file
            Config = AppConfig.FromFile(ConfigFile);

            //rewrite config file (in case config layout changed, to add the missing keys)
            Config.ToFile(ConfigFile);
        }

        /// <summary>
        /// Try to kill stray castsvr instances
        /// </summary>
        static void TryKillCastServer()
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName.Equals("CastSrv", StringComparison.OrdinalIgnoreCase))
                    {
                        Debug.WriteLine($"Killing CastSrv with PID {p.Id}");
                        p.Kill(true);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"TryKillCastServer(): {e}");
            }
        }
    }
}
