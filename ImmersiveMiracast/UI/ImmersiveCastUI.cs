using Microsoft.Toolkit.Forms.UI.Controls;
using System.Drawing;
using System.Windows.Forms;
using UWPMediaPlayer = Windows.Media.Playback.MediaPlayer;

namespace ImmersiveMiracast.UI
{
    /// <summary>
    /// fullscreen cast display ui
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
            InitUI();
        }

        /// <summary>
        /// initialize the cast ui
        /// </summary>
        /// <param name="title">the title for the window</param>
        /// <param name="player">player to render to the window</param>
        public ImmersiveCastUI(string title, UWPMediaPlayer player) : this()
        {
            //set title
            Text = title;

            //set player to render to media element
            mediaPlayerElement.SetMediaPlayer(player);

            //be immersive
            GoImmersive();
        }

        /// <summary>
        /// initialize the ui, manually because forms designer for dotnet core is broken :|
        /// </summary>
        void InitUI()
        {
            SuspendLayout();

            //set window background to black
            BackColor = Color.Black;

            //init media player element
            mediaPlayerElement = new MediaPlayerElement()
            {
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                Stretch = Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.Stretch.UniformToFill
            };
            Controls.Add(mediaPlayerElement);

            ResumeLayout();
        }

        /// <summary>
        /// enter fullscreen to finish immersive mode
        /// </summary>
        void GoImmersive()
        {
            //window go -brr- fullscreen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //cursor go hide
            Cursor.Hide();
        }
    }
}
