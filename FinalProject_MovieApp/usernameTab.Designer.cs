namespace FinalProject_MovieApp
{
    partial class usernameTab
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
            this.userTab = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.userTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // userTab
            // 
            this.userTab.BackColor = System.Drawing.Color.Red;
            this.userTab.Controls.Add(this.label1);
            this.userTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userTab.Location = new System.Drawing.Point(0, 0);
            this.userTab.Name = "userTab";
            this.userTab.Size = new System.Drawing.Size(150, 70);
            this.userTab.TabIndex = 1;
            this.userTab.Click += new System.EventHandler(this.userTab_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "USERNAME";
            // 
            // usernameTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userTab);
            this.Name = "usernameTab";
            this.Size = new System.Drawing.Size(150, 70);
            this.userTab.ResumeLayout(false);
            this.userTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userTab;
        private System.Windows.Forms.Label label1;
    }
}
