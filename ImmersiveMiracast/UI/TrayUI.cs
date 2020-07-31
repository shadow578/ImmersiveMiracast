using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmersiveMiracast.UI
{
    /// <summary>
    /// the tray icon and some extra logic around it
    /// </summary>
    public class TrayUI : IDisposable
    {
        /// <summary>
        /// the tray icon of the ui
        /// </summary>
        NotifyIcon trayIcon;

        /// <summary>
        /// right click menu of the icon
        /// </summary>
        ContextMenuStrip menu = new ContextMenuStrip();

        /// <summary>
        /// initialize the tray icon
        /// </summary>
        /// <param name="title">title to use for the icon</param>
        /// <param name="icon">icon to display</param>
        public void Init(string title, Icon icon = null)
        {
            //default icon
            if (icon == null)
            {
                icon = SystemIcons.Error;
            }

            //init tray icon
            trayIcon = new NotifyIcon()
            {
                Visible = true,
                Text = title,
                Icon = icon,
                ContextMenuStrip = menu
            };
        }

        /// <summary>
        /// add a item to the right click menu
        /// </summary>
        /// <param name="title">title of the item</param>
        /// <param name="onClick">click handler for the item</param>
        public void AddMenuItem(string title, EventHandler onClick)
        {
            menu.Items.Add(title, null, onClick);
        }

        /// <summary>
        /// show a toast message
        /// </summary>
        /// <param name="title">the title of the message</param>
        /// <param name="text">the text of the message</param>
        /// <param name="timeout">how many ms the toast is shown</param>
        public void ShowToast(string title, string text, int timeout = 5000)
        {
            //show balloon
            trayIcon.ShowBalloonTip(timeout, title, text, ToolTipIcon.None);

            //hide baloon after timeout
            Task.Run(async () =>
            {
                await Task.Delay(timeout);
                if (trayIcon == null) return;
                trayIcon.Visible = false;
                trayIcon.Visible = true;
            });
        }

        /// <summary>
        /// dispose the tray ui
        /// </summary>
        public void Dispose()
        {
            trayIcon.Dispose();
        }
    }
}
