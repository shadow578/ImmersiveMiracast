namespace ImmersiveMiracast.UI
{
    partial class PinUI
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
            this.lPin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lPin
            // 
            this.lPin.AutoSize = true;
            this.lPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPin.Font = new System.Drawing.Font("Segoe UI", 75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lPin.Location = new System.Drawing.Point(0, 0);
            this.lPin.Name = "lPin";
            this.lPin.Size = new System.Drawing.Size(855, 133);
            this.lPin.TabIndex = 0;
            this.lPin.Text = "Pin: XXXXXXXXX";
            // 
            // PinUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(936, 192);
            this.ControlBox = false;
            this.Controls.Add(this.lPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PinUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PinUI";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lPin;
    }
}