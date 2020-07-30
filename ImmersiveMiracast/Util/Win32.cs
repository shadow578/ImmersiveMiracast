using Microsoft.Win32;

namespace ImmersiveMiracast.Util
{
    /// <summary>
    /// helper class for all things win32
    /// </summary>
    public static class Win32Util
    {
        /// <summary>
        /// register the app for autostart under the current user
        /// </summary>
        /// <param name="appName">the name of the app</param>
        /// <param name="appExePath">the path of the app's executeable</param>
        /// <param name="shouldAutoStart">should autostart be enabled (true) or disabled (false)?</param>
        public static void RegisterAutostart(string appName, string appExePath, bool shouldAutoStart)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (shouldAutoStart)
            {
                //(re)write autostart key
                registryKey.SetValue(appName, appExePath);
            }
            else
            {
                //delete autostart key
                if (registryKey.GetValue(appName) != null)
                    registryKey.DeleteValue(appName);
            }
        }
    }
}
