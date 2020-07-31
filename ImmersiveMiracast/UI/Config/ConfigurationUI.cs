using ImmersiveMiracast.Core;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ImmersiveMiracast.UI.Config
{
    /// <summary>
    /// UI to configure the app
    /// </summary>
    public partial class ConfigurationUI : Form
    {
        /// <summary>
        /// path to the config file
        /// </summary>
        readonly string cfgPath;

        /// <summary>
        /// The current configuration object
        /// </summary>
        AppConfig currentConfig;

        protected ConfigurationUI()
        {
            InitializeComponent();
            Icon = SharedResources.app_icon;
        }

        /// <summary>
        /// initialize the config ui
        /// </summary>
        /// <param name="configPath">the path to the configuration file</param>
        public ConfigurationUI(string configPath) : this()
        {
            cfgPath = configPath;
            ReloadConfigFile();
        }

        /// <summary>
        /// reload the config file and update the ui
        /// </summary>
        void ReloadConfigFile()
        {
            //load config
            currentConfig = AppConfig.FromFile(cfgPath);

            //update ui
            ConfigToUI(currentConfig);
        }

        /// <summary>
        /// populates the ui with the values from the config
        /// </summary>
        /// <param name="cfg">the config to use</param>
        void ConfigToUI(AppConfig cfg)
        {
            //populate screen ids
            PopulateScreenIds();

            //app settings
            tCastDisplayName.Text = cfg.CastDisplayName;
            cShouldAppAutostart.Checked = cfg.ShouldAppAutostart;
            if (cfg.CastDisplayId < 0 || cfg.CastDisplayId >= Screen.AllScreens.Length)
            {
                cbCastScreenId.SelectedIndex = 0;
                cCastPrimaryScreen.Checked = true;
            }
            else
            {
                cbCastScreenId.SelectedIndex = cfg.CastDisplayId;
                cCastPrimaryScreen.Checked = false;
            }

            //strings
            tAppName.Text = cfg.Strings.AppName;
            tCastReady.Text = cfg.Strings.CastReady;
            tCastWelcome.Text = cfg.Strings.CastWelcome;
            tTrayConfigure.Text = cfg.Strings.TrayConfigure;
            tTrayRestartSession.Text = cfg.Strings.TrayRestartSession;
            tTrayRestartApp.Text = cfg.Strings.TrayRestartApp;
            tTrayExitApp.Text = cfg.Strings.TrayExitApp;
        }

        /// <summary>
        /// repopulate cbCastScreenId.Items
        /// </summary>
        void PopulateScreenIds()
        {
            cbCastScreenId.Items.Clear();
            for (int si = 0; si < Screen.AllScreens.Length; si++)
            {
                cbCastScreenId.Items.Add($"{si} - {Screen.AllScreens[si].DeviceName}");
            }
        }

        /// <summary>
        /// writes back values from the ui into the config
        /// </summary>
        /// <param name="cfg">the config to use</param>
        void UIToConfig(AppConfig cfg)
        {
            //app settings
            cfg.CastDisplayName = tCastDisplayName.Text;
            cfg.ShouldAppAutostart = cShouldAppAutostart.Checked;
            if (cCastPrimaryScreen.Checked)
            {
                cfg.CastDisplayId = 0;
            }
            else
            {
                cfg.CastDisplayId = cbCastScreenId.SelectedIndex;
            }

            //strings
            cfg.Strings.AppName = tAppName.Text;
            cfg.Strings.CastReady = tCastReady.Text;
            cfg.Strings.CastWelcome = tCastWelcome.Text;
            cfg.Strings.TrayConfigure = tTrayConfigure.Text;
            cfg.Strings.TrayRestartSession = tTrayRestartSession.Text;
            cfg.Strings.TrayRestartApp = tTrayRestartApp.Text;
            cfg.Strings.TrayExitApp = tTrayExitApp.Text;
        }

        #region UI Events
        /// <summary>
        /// cast to primary screen checkbox changed, toggle screen id combobox
        /// </summary>
        void OnCastToPrimaryScreenChange(object sender, EventArgs e)
        {
            cbCastScreenId.Enabled = !cCastPrimaryScreen.Checked;
            btnIdentifyScreenIds.Enabled = !cCastPrimaryScreen.Checked;
        }

        /// <summary>
        /// identify screens button clicked, show screen identification ui
        /// </summary>
        void OnIdentifyScreenIds(object sender, EventArgs e)
        {
            ScreenIdentifierUI.IdentifyAllScreens();
        }

        /// <summary>
        /// reset config button clicked, reset, save, and reload config
        /// </summary>
        void OnResetConfig(object sender, EventArgs e)
        {
            //ask if reset is ok
            if (MessageBox.Show(this, currentConfig.Strings.ResetConfigConfirmation, currentConfig.Strings.AppName, MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            //user ok with reset
            currentConfig = new AppConfig();
            currentConfig.ToFile(cfgPath);
            ReloadConfigFile();
        }

        /// <summary>
        /// open config in editor button was clicked, open config file in notepad
        /// </summary>
        void OnOpenConfigInEditor(object sender, EventArgs e)
        {
            Process.Start(currentConfig.ConfigureCommand, cfgPath);
        }

        /// <summary>
        /// cancel button was clicked, exit without saving
        /// </summary>
        void OnCancel(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// apply button was clicked, save and exit
        /// </summary>
        void OnApply(object sender, EventArgs e)
        {
            //save config
            UIToConfig(currentConfig);
            currentConfig.ToFile(cfgPath);

            //close ui & restart app
            App.ShouldRestartApp = true;
            Application.Exit();
            Close();
        }
        #endregion
    }
}
