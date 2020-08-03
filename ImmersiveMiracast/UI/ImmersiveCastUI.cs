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
        /// is the window in immersive mode?
        /// </summary>
        public bool Immersive
        {
            get
            {
                return WindowState == FormWindowState.Maximized;
            }
            set
            {
                FormBorderStyle = FormBorderStyle.None;
                if (value)
                {
                    //window go brr
                    WindowState = FormWindowState.Maximized;

                    //cursor go hide
                    Cursor.Hide();
                }
                else
                {
                    //window go brr
                    WindowState = FormWindowState.Normal;

                    //cursor go hide
                    Cursor.Show();
                }
            }
        }

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
        }

        /// <summary>
        /// move the window to the sceen
        /// </summary>
        /// <param name="screenId">screen to display the ui on. this is a index to Screen.AllScreens. use -1 to use the primary screen</param>
        public void MoveToScreen(int screenId = -1)
        {
            //get which screen to move to, default is primary
            Screen targetScreen = Screen.PrimaryScreen;
            if(screenId >= 0 && screenId <= Screen.AllScreens.Length)
            {
                targetScreen = Screen.AllScreens[screenId];
            }

            //move to screen
            Location = targetScreen.Bounds.Location;
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
        /// show the UI and make it fullscreen
        /// </summary>
        public void ShowImmersive()
        {
            Show();
            Immersive = true;
        }

        /// <summary>
        /// dispose xaml controls and hide the ui.
        /// also disables immersive mode
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

            //disable immersive mode
            Immersive = false;

            //hide ui
            base.Hide();
        }
    }
}
