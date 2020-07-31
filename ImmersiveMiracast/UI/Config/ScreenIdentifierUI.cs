using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmersiveMiracast.UI.Config
{
    /// <summary>
    /// Ui and util functions to identify screen ids
    /// </summary>
    public partial class ScreenIdentifierUI : Form
    {
        #region Helpers
        /// <summary>
        /// identify all screens
        /// </summary>
        /// <param name="timeout">for how long to show the ui</param>
        public static void IdentifyAllScreens(int timeout = 5000)
        {
            for (int si = 0; si < Screen.AllScreens.Length; si++)
                IdentifyScreen(si, timeout);
        }

        /// <summary>
        /// identify the screen with the given id
        /// </summary>
        /// <param name="id">the id of the screen to identify</param>
        /// <param name="timeout">for how long to show the ui</param>
        public static void IdentifyScreen(int id, int timeout = 5000)
        {
            //bounds check
            if (id < 0 || id >= Screen.AllScreens.Length) return;

            //show ui
            ScreenIdentifierUI ui = new ScreenIdentifierUI(id);
            ui.Show();

            //hide ui after timeout
            Task.Run(async () =>
            {
                await Task.Delay(timeout);
                ui.Invoke(new MethodInvoker(() =>
                {
                    ui.Close();
                }));
            });
        }
        #endregion

        /// <summary>
        /// init the ui
        /// </summary>
        /// <param name="id">id of the screen to identify</param>
        protected ScreenIdentifierUI(int id)
        {
            //init ui
            InitializeComponent();
            lScreenId.Text = id.ToString();

            //get screen to identify
            if (id < 0 || id >= Screen.AllScreens.Length)
            {
                Visible = false;
                return;
            }

            //center on the screen
            CenterOnScreen(Screen.AllScreens[id]);
        }

        /// <summary>
        /// Center the ui on the specified screen
        /// </summary>
        /// <param name="screen">the screen to center on</param>
        void CenterOnScreen(Screen screen)
        {
            if (screen == null) return;

            //get values from screen
            int screenXOffset = screen.Bounds.X;
            int screenYOffset = screen.Bounds.Y;
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            //calculate x and y center coordinates
            int windowX = screenXOffset + (screenWidth / 2);
            int windowY = screenYOffset + (screenHeight / 2);

            //offset to have window centered
            windowX -= Size.Width / 2;
            windowY -= Size.Height / 2;

            //set location
            Location = new Point(windowX, windowY);
        }
    }
}
