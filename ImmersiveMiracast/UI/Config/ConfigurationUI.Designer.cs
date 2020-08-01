namespace ImmersiveMiracast.UI.Config
{
    partial class ConfigurationUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupStrings;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupApp;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Button btnResetConfig;
            System.Windows.Forms.Button btnOpenConfigInEditor;
            this.tTrayExitApp = new System.Windows.Forms.TextBox();
            this.tTrayRestartApp = new System.Windows.Forms.TextBox();
            this.tTrayRestartSession = new System.Windows.Forms.TextBox();
            this.tTrayConfigure = new System.Windows.Forms.TextBox();
            this.tCastWelcome = new System.Windows.Forms.TextBox();
            this.tCastReady = new System.Windows.Forms.TextBox();
            this.tAppName = new System.Windows.Forms.TextBox();
            this.cCastRequirePin = new System.Windows.Forms.CheckBox();
            this.btnIdentifyScreenIds = new System.Windows.Forms.Button();
            this.cbCastScreenId = new System.Windows.Forms.ComboBox();
            this.cCastPrimaryScreen = new System.Windows.Forms.CheckBox();
            this.tCastDisplayName = new System.Windows.Forms.TextBox();
            this.cShouldAppAutostart = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sharedTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupAdvanced = new System.Windows.Forms.GroupBox();
            this.tCastPinMessage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            groupStrings = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupApp = new System.Windows.Forms.GroupBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            btnResetConfig = new System.Windows.Forms.Button();
            btnOpenConfigInEditor = new System.Windows.Forms.Button();
            groupStrings.SuspendLayout();
            groupApp.SuspendLayout();
            this.groupAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupStrings
            // 
            groupStrings.Controls.Add(this.label10);
            groupStrings.Controls.Add(this.tCastPinMessage);
            groupStrings.Controls.Add(this.tTrayExitApp);
            groupStrings.Controls.Add(label7);
            groupStrings.Controls.Add(this.tTrayRestartApp);
            groupStrings.Controls.Add(label6);
            groupStrings.Controls.Add(this.tTrayRestartSession);
            groupStrings.Controls.Add(label5);
            groupStrings.Controls.Add(this.tTrayConfigure);
            groupStrings.Controls.Add(label4);
            groupStrings.Controls.Add(this.tCastWelcome);
            groupStrings.Controls.Add(label3);
            groupStrings.Controls.Add(this.tCastReady);
            groupStrings.Controls.Add(label2);
            groupStrings.Controls.Add(this.tAppName);
            groupStrings.Controls.Add(label1);
            groupStrings.Location = new System.Drawing.Point(435, 15);
            groupStrings.Name = "groupStrings";
            groupStrings.Size = new System.Drawing.Size(516, 258);
            groupStrings.TabIndex = 0;
            groupStrings.TabStop = false;
            groupStrings.Text = "Strings";
            // 
            // tTrayExitApp
            // 
            this.tTrayExitApp.Location = new System.Drawing.Point(129, 225);
            this.tTrayExitApp.MaxLength = 255;
            this.tTrayExitApp.Name = "tTrayExitApp";
            this.tTrayExitApp.Size = new System.Drawing.Size(373, 23);
            this.tTrayExitApp.TabIndex = 110;
            this.sharedTooltip.SetToolTip(this.tTrayExitApp, "\"exit app\" option in tray menu");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 228);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(83, 15);
            label7.TabIndex = 0;
            label7.Text = "Exit App (Tray)";
            // 
            // tTrayRestartApp
            // 
            this.tTrayRestartApp.Location = new System.Drawing.Point(129, 196);
            this.tTrayRestartApp.MaxLength = 255;
            this.tTrayRestartApp.Name = "tTrayRestartApp";
            this.tTrayRestartApp.Size = new System.Drawing.Size(373, 23);
            this.tTrayRestartApp.TabIndex = 100;
            this.sharedTooltip.SetToolTip(this.tTrayRestartApp, "\"restart app\" option in tray menu");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 199);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(100, 15);
            label6.TabIndex = 0;
            label6.Text = "Restart App (Tray)";
            // 
            // tTrayRestartSession
            // 
            this.tTrayRestartSession.Location = new System.Drawing.Point(129, 167);
            this.tTrayRestartSession.MaxLength = 255;
            this.tTrayRestartSession.Name = "tTrayRestartSession";
            this.tTrayRestartSession.Size = new System.Drawing.Size(373, 23);
            this.tTrayRestartSession.TabIndex = 90;
            this.sharedTooltip.SetToolTip(this.tTrayRestartSession, "\"restart session\" option in tray menu");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 170);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(117, 15);
            label5.TabIndex = 0;
            label5.Text = "Restart Session (Tray)";
            // 
            // tTrayConfigure
            // 
            this.tTrayConfigure.Location = new System.Drawing.Point(129, 138);
            this.tTrayConfigure.MaxLength = 255;
            this.tTrayConfigure.Name = "tTrayConfigure";
            this.tTrayConfigure.Size = new System.Drawing.Size(373, 23);
            this.tTrayConfigure.TabIndex = 80;
            this.sharedTooltip.SetToolTip(this.tTrayConfigure, "\"configure\" option in tray menu");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 141);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(92, 15);
            label4.TabIndex = 0;
            label4.Text = "Configure (Tray)";
            // 
            // tCastWelcome
            // 
            this.tCastWelcome.Location = new System.Drawing.Point(129, 109);
            this.tCastWelcome.MaxLength = 255;
            this.tCastWelcome.Name = "tCastWelcome";
            this.tCastWelcome.Size = new System.Drawing.Size(373, 23);
            this.tCastWelcome.TabIndex = 70;
            this.sharedTooltip.SetToolTip(this.tCastWelcome, "casting to the receiver started\r\n{DisplayName}: display name of the receiver\r\n{Tr" +
        "ansmitter}: display name of the transmitter currently casting");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 112);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 15);
            label3.TabIndex = 0;
            label3.Text = "Cast Welcome";
            // 
            // tCastReady
            // 
            this.tCastReady.Location = new System.Drawing.Point(129, 51);
            this.tCastReady.MaxLength = 255;
            this.tCastReady.Name = "tCastReady";
            this.tCastReady.Size = new System.Drawing.Size(373, 23);
            this.tCastReady.TabIndex = 60;
            this.sharedTooltip.SetToolTip(this.tCastReady, "app is ready to receive\r\n{DisplayName}: display name of the receiver");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 15);
            label2.TabIndex = 0;
            label2.Text = "Cast Ready";
            // 
            // tAppName
            // 
            this.tAppName.Location = new System.Drawing.Point(129, 22);
            this.tAppName.MaxLength = 255;
            this.tAppName.Name = "tAppName";
            this.tAppName.Size = new System.Drawing.Size(373, 23);
            this.tAppName.TabIndex = 50;
            this.sharedTooltip.SetToolTip(this.tAppName, "name of the app, used in ui");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "App Name";
            // 
            // groupApp
            // 
            groupApp.Controls.Add(this.cCastRequirePin);
            groupApp.Controls.Add(this.btnIdentifyScreenIds);
            groupApp.Controls.Add(label9);
            groupApp.Controls.Add(this.cbCastScreenId);
            groupApp.Controls.Add(this.cCastPrimaryScreen);
            groupApp.Controls.Add(label8);
            groupApp.Controls.Add(this.tCastDisplayName);
            groupApp.Controls.Add(this.cShouldAppAutostart);
            groupApp.Location = new System.Drawing.Point(15, 15);
            groupApp.Name = "groupApp";
            groupApp.Size = new System.Drawing.Size(414, 199);
            groupApp.TabIndex = 0;
            groupApp.TabStop = false;
            groupApp.Text = "App Settings";
            // 
            // cCastRequirePin
            // 
            this.cCastRequirePin.AutoSize = true;
            this.cCastRequirePin.Location = new System.Drawing.Point(6, 140);
            this.cCastRequirePin.Name = "cCastRequirePin";
            this.cCastRequirePin.Size = new System.Drawing.Size(148, 19);
            this.cCastRequirePin.TabIndex = 30;
            this.cCastRequirePin.Text = "Require Pin to Connect";
            this.cCastRequirePin.UseVisualStyleBackColor = true;
            this.cCastRequirePin.CheckedChanged += new System.EventHandler(this.OnCastToPrimaryScreenChange);
            // 
            // btnIdentifyScreenIds
            // 
            this.btnIdentifyScreenIds.Location = new System.Drawing.Point(282, 106);
            this.btnIdentifyScreenIds.Name = "btnIdentifyScreenIds";
            this.btnIdentifyScreenIds.Size = new System.Drawing.Size(75, 23);
            this.btnIdentifyScreenIds.TabIndex = 3;
            this.btnIdentifyScreenIds.Text = "Identify";
            this.sharedTooltip.SetToolTip(this.btnIdentifyScreenIds, "identify screen ids");
            this.btnIdentifyScreenIds.UseVisualStyleBackColor = true;
            this.btnIdentifyScreenIds.Click += new System.EventHandler(this.OnIdentifyScreenIds);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 112);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(82, 15);
            label9.TabIndex = 0;
            label9.Text = "Cast Screen ID";
            // 
            // cbCastScreenId
            // 
            this.cbCastScreenId.FormattingEnabled = true;
            this.cbCastScreenId.Location = new System.Drawing.Point(98, 107);
            this.cbCastScreenId.Name = "cbCastScreenId";
            this.cbCastScreenId.Size = new System.Drawing.Size(178, 23);
            this.cbCastScreenId.TabIndex = 40;
            this.sharedTooltip.SetToolTip(this.cbCastScreenId, "Screen id to use for casting (this changes if display setup changes)");
            // 
            // cCastPrimaryScreen
            // 
            this.cCastPrimaryScreen.AutoSize = true;
            this.cCastPrimaryScreen.Location = new System.Drawing.Point(6, 82);
            this.cCastPrimaryScreen.Name = "cCastPrimaryScreen";
            this.cCastPrimaryScreen.Size = new System.Drawing.Size(145, 19);
            this.cCastPrimaryScreen.TabIndex = 30;
            this.cCastPrimaryScreen.Text = "Cast to primary Screen";
            this.sharedTooltip.SetToolTip(this.cCastPrimaryScreen, "cast to the primary screen");
            this.cCastPrimaryScreen.UseVisualStyleBackColor = true;
            this.cCastPrimaryScreen.CheckedChanged += new System.EventHandler(this.OnCastToPrimaryScreenChange);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 25);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(86, 15);
            label8.TabIndex = 0;
            label8.Text = "Receiver Name";
            // 
            // tCastDisplayName
            // 
            this.tCastDisplayName.Location = new System.Drawing.Point(98, 22);
            this.tCastDisplayName.MaxLength = 50;
            this.tCastDisplayName.Name = "tCastDisplayName";
            this.tCastDisplayName.Size = new System.Drawing.Size(300, 23);
            this.tCastDisplayName.TabIndex = 10;
            this.sharedTooltip.SetToolTip(this.tCastDisplayName, "name to display for the receiver on other devices");
            // 
            // cShouldAppAutostart
            // 
            this.cShouldAppAutostart.AutoSize = true;
            this.cShouldAppAutostart.Location = new System.Drawing.Point(6, 53);
            this.cShouldAppAutostart.Name = "cShouldAppAutostart";
            this.cShouldAppAutostart.Size = new System.Drawing.Size(100, 19);
            this.cShouldAppAutostart.TabIndex = 20;
            this.cShouldAppAutostart.Text = "Autostart App";
            this.sharedTooltip.SetToolTip(this.cShouldAppAutostart, "Add the app to autostart of the current user");
            this.cShouldAppAutostart.UseVisualStyleBackColor = true;
            // 
            // btnResetConfig
            // 
            btnResetConfig.Location = new System.Drawing.Point(6, 19);
            btnResetConfig.Name = "btnResetConfig";
            btnResetConfig.Size = new System.Drawing.Size(137, 23);
            btnResetConfig.TabIndex = 48;
            btnResetConfig.Text = "Reset to Default";
            this.sharedTooltip.SetToolTip(btnResetConfig, "reset config settings to default");
            btnResetConfig.UseVisualStyleBackColor = true;
            btnResetConfig.Click += new System.EventHandler(this.OnResetConfig);
            // 
            // btnOpenConfigInEditor
            // 
            btnOpenConfigInEditor.Location = new System.Drawing.Point(271, 19);
            btnOpenConfigInEditor.Name = "btnOpenConfigInEditor";
            btnOpenConfigInEditor.Size = new System.Drawing.Size(137, 23);
            btnOpenConfigInEditor.TabIndex = 49;
            btnOpenConfigInEditor.Text = "Open in Editor";
            this.sharedTooltip.SetToolTip(btnOpenConfigInEditor, "Open the config file in a text editor");
            btnOpenConfigInEditor.UseVisualStyleBackColor = true;
            btnOpenConfigInEditor.Click += new System.EventHandler(this.OnOpenConfigInEditor);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(796, 281);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 130;
            this.btnApply.Text = "Apply";
            this.sharedTooltip.SetToolTip(this.btnApply, "Save changes and exit window");
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApply);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 23);
            this.btnCancel.TabIndex = 120;
            this.btnCancel.Text = "Cancel";
            this.sharedTooltip.SetToolTip(this.btnCancel, "Discard changes and exit window");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // groupAdvanced
            // 
            this.groupAdvanced.Controls.Add(btnOpenConfigInEditor);
            this.groupAdvanced.Controls.Add(btnResetConfig);
            this.groupAdvanced.Location = new System.Drawing.Point(15, 220);
            this.groupAdvanced.Name = "groupAdvanced";
            this.groupAdvanced.Size = new System.Drawing.Size(414, 53);
            this.groupAdvanced.TabIndex = 4;
            this.groupAdvanced.TabStop = false;
            this.groupAdvanced.Text = "Advanced";
            // 
            // tCastPinMessage
            // 
            this.tCastPinMessage.Location = new System.Drawing.Point(129, 80);
            this.tCastPinMessage.MaxLength = 255;
            this.tCastPinMessage.Name = "tCastPinMessage";
            this.tCastPinMessage.Size = new System.Drawing.Size(373, 23);
            this.tCastPinMessage.TabIndex = 110;
            this.sharedTooltip.SetToolTip(this.tCastPinMessage, "message shown when a pin is required to authentificate\r\n{DisplayName}: display na" +
        "me of the receiver\r\n{Transmitter}: name of the transmitter to authentificate\r\n{P" +
        "in}: the pin to authentificate");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Pin Message";
            // 
            // ConfigurationUI
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(959, 319);
            this.Controls.Add(this.groupAdvanced);
            this.Controls.Add(groupApp);
            this.Controls.Add(groupStrings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigurationUI";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "ImmersiveCast Configuration";
            groupStrings.ResumeLayout(false);
            groupStrings.PerformLayout();
            groupApp.ResumeLayout(false);
            groupApp.PerformLayout();
            this.groupAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip sharedTooltip;
        private System.Windows.Forms.TextBox tAppName;
        private System.Windows.Forms.TextBox tTrayRestartSession;
        private System.Windows.Forms.TextBox tTrayConfigure;
        private System.Windows.Forms.TextBox tCastWelcome;
        private System.Windows.Forms.TextBox tCastReady;
        private System.Windows.Forms.TextBox tTrayExitApp;
        private System.Windows.Forms.TextBox tTrayRestartApp;
        private System.Windows.Forms.CheckBox cShouldAppAutostart;
        private System.Windows.Forms.TextBox tCastDisplayName;
        private System.Windows.Forms.ComboBox cbCastScreenId;
        private System.Windows.Forms.CheckBox cCastPrimaryScreen;
        private System.Windows.Forms.GroupBox groupAdvanced;
        private System.Windows.Forms.Button btnIdentifyScreenIds;
        private System.Windows.Forms.CheckBox cCastRequirePin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tCastPinMessage;
    }
}