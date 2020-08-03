namespace ImmersiveMiracast.UI
{
    partial class ImmersiveCastUI
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
            this.lPin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPin.Font = new System.Drawing.Font("Segoe UI", 90F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lPin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lPin.Location = new System.Drawing.Point(0, 0);
            this.lPin.Name = "lPin";
            this.lPin.Size = new System.Drawing.Size(800, 450);
            this.lPin.TabIndex = 0;
            this.lPin.Text = "FooBar\'s Pin:\r\nXXXXXXX";
            this.lPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImmersiveCastUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.lPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Name = "ImmersiveCastUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ImmersiveCastUI";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lPin;
    }
}