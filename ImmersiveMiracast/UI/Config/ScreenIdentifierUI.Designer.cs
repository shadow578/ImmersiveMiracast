namespace ImmersiveMiracast.UI.Config
{
    partial class ScreenIdentifierUI
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
            this.lScreenId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lScreenId
            // 
            this.lScreenId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lScreenId.Font = new System.Drawing.Font("Segoe UI", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lScreenId.Location = new System.Drawing.Point(0, 0);
            this.lScreenId.Name = "lScreenId";
            this.lScreenId.Size = new System.Drawing.Size(300, 300);
            this.lScreenId.TabIndex = 0;
            this.lScreenId.Text = "0";
            this.lScreenId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScreenIdentifierUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.ControlBox = false;
            this.Controls.Add(this.lScreenId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenIdentifierUI";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Screen Identifier";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lScreenId;
    }
}