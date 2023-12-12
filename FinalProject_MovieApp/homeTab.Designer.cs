namespace FinalProject_MovieApp
{
    partial class homeTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.home = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.home.SuspendLayout();
            this.SuspendLayout();
            // 
            // home
            // 
            this.home.BackColor = System.Drawing.Color.Red;
            this.home.Controls.Add(this.label1);
            this.home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home.Dock = System.Windows.Forms.DockStyle.Fill;
            this.home.Location = new System.Drawing.Point(0, 0);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(150, 70);
            this.home.TabIndex = 2;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOME";
            // 
            // homeTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.home);
            this.Name = "homeTab";
            this.Size = new System.Drawing.Size(150, 70);
            this.home.ResumeLayout(false);
            this.home.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel home;
        private System.Windows.Forms.Label label1;
    }
}
