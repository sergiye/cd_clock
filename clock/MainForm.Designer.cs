namespace Clock
{
    partial class MainForm
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
      this.btnSay = new System.Windows.Forms.Button();
      this.tickTackTimer = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // btnSay
      // 
      this.btnSay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnSay.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnSay.Location = new System.Drawing.Point(0, 0);
      this.btnSay.Name = "btnSay";
      this.btnSay.Size = new System.Drawing.Size(355, 95);
      this.btnSay.TabIndex = 0;
      this.btnSay.Text = "00:00:00";
      this.btnSay.UseVisualStyleBackColor = true;
      this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
      this.btnSay.Resize += new System.EventHandler(this.btnSay_Resize);
      // 
      // tickTackTimer
      // 
      this.tickTackTimer.Enabled = true;
      this.tickTackTimer.Interval = 500;
      this.tickTackTimer.Tick += new System.EventHandler(this.tickTackTimer_Tick);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(355, 95);
      this.Controls.Add(this.btnSay);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "CD-Clock";
      this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSay;
        private System.Windows.Forms.Timer tickTackTimer;
    }
}

