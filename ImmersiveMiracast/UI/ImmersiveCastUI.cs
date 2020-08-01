using Microsoft.Toolkit.Forms.UI.Controls;
using System.Drawing;
using System.Windows.Forms;
using UWPMediaPlayer = Windows.Media.Playback.MediaPlayer;

namespace ImmersiveMiracast.UI
{
    /// <summary>
    /// fullscreen cast and pin display ui
    /// </summary>
    public partial class ImmersiveCastUI : Form
    {
        /// <summary>
        /// media player element for rendering video frames to
        /// </summary>
        MediaPlayerElement mediaPlayerElement;

        /// <summary>
        /// initialize the ui with default settings.
        /// </summary>
        protected ImmersiveCastUI()
        {
            InitializeComponent();
            lPin.Visible = false;
        }

        /// <summary>
        /// initialize the cast ui on the primary screen
        /// </summary>
        /// <param name="title">the title for the window</param>
        public ImmersiveCastUI(string title) : this()
        {
            //set title
            Text = title;

            //move window to primary scrren
            Location = Screen.PrimaryScreen.Bounds.Location;

            //be immersive
            GoImmersive();
        }

        /// <summary>
        /// initialize the cast ui on the given screen
        /// </summary>
        /// <param name="title">the title for the window</param>
        /// <param name="screen">screen to display the ui on. this is a index to Screen.AllScreens</param>
        public ImmersiveCastUI(string title, int screen) : this()
        {
            //set title
            Text = title;

            //move window to desired screen, check bounds first
            if (screen < 0 || screen >= Screen.AllScreens.Length)
            {
                //default to primary screen
                Location = Screen.PrimaryScreen.Bounds.Location;
            }
            else
            {
                //move to desired screen
                Location = Screen.AllScreens[screen].Bounds.Location;
            }

            //be immersive
            GoImmersive();
        }

        /// <summary>
        /// set the pin displayed on the ui.
        /// Only valid if SetCastSource() was not yet called
        /// </summary>
        /// <param name="pinMsg">the pin (message) to display (can be multi- line)</param>
        public void SetPin(string pinMsg)
        {
            if (mediaPlayerElement != null) return;

            //set pin display
            lPin.Text = pinMsg;
            lPin.Visible = true;
        }

        /// <summary>
        /// set the cast source that should render on the ui
        /// </summary>
        /// <param name="castPlayer">the player to render on the ui</param>
        public void SetCastSource(UWPMediaPlayer castPlayer)
        {
            //hide pin display
            lPin.Visible = false;

            //clear old mediaplayer element
            if (mediaPlayerElement != null)
            {
                Controls.Remove(mediaPlayerElement);
                mediaPlayerElement.Dispose();
            }

            //init new media player element
            mediaPlayerElement = new MediaPlayerElement()
            {
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                Stretch = Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.Stretch.UniformToFill
            };

            //set player to render to media element
            mediaPlayerElement.SetMediaPlayer(castPlayer);

            //add to window
            Controls.Add(mediaPlayerElement);
        }

        /// <summary>
        /// dispose xaml controls and hide the ui.
        /// This allows reuse of the control
        /// </summary>
        public new void Hide()
        {
            //dispose xaml components
            if (mediaPlayerElement != null)
            {
                Controls.Remove(mediaPlayerElement);
                mediaPlayerElement.Dispose();
                mediaPlayerElement = null;
            }

            //hide ui
            base.Hide();
        }

        /// <summary>
        /// enter fullscreen to finish immersive mode
        /// </summary>
        void GoImmersive()
        {
            //window go brr
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //cursor go hide
            Cursor.Hide();

            //unhide cursor when window exits
            FormClosing += (se, no) =>
            {
                Cursor.Show();
            };
        }
    }
}
