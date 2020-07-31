using System.Drawing;
using System.Windows.Forms;

namespace ImmersiveMiracast.UI
{
    /// <summary>
    /// UI to display a pin on a screen
    /// </summary>
    public partial class PinUI : Form
    {
        /// <summary>
        /// init the ui
        /// </summary>
        protected PinUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// init the ui on the primary screen
        /// </summary>
        /// <param name="pin">the pin (message) to display</param>
        public PinUI(string pin) : this()
        {
            //set pin text
            lPin.Text = pin;

            //center on the primary screen
            CenterOnScreen(Screen.PrimaryScreen);
        }

        /// <summary>
        /// init the ui on the specified screen
        /// </summary>
        /// <param name="pin">the pin (message) to display</param>
        /// <param name="displayId">the screen to display on</param>
        public PinUI(string pin, int displayId) : this()
        {
            //set pin text
            lPin.Text = pin;

            //get screen to identify
            if (displayId < 0 || displayId >= Screen.AllScreens.Length)
                displayId = 0;

            //center on the screen
            CenterOnScreen(Screen.AllScreens[displayId]);
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
