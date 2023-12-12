namespace FinalProject_MovieApp
{
    partial class tabs
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.homeTab1 = new FinalProject_MovieApp.homeTab();
            this.favouritesTab1 = new FinalProject_MovieApp.favouritesTab();
            this.watchListTab1 = new FinalProject_MovieApp.watchListTab();
            this.usernameTab1 = new FinalProject_MovieApp.usernameTab();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.usernameTab1);
            this.panel1.Controls.Add(this.watchListTab1);
            this.panel1.Controls.Add(this.favouritesTab1);
            this.panel1.Controls.Add(this.homeTab1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 70);
            this.panel1.TabIndex = 0;
            // 
            // homeTab1
            // 
            this.homeTab1.Location = new System.Drawing.Point(0, 0);
            this.homeTab1.Name = "homeTab1";
            this.homeTab1.Size = new System.Drawing.Size(150, 70);
            this.homeTab1.TabIndex = 0;
            // 
            // favouritesTab1
            // 
            this.favouritesTab1.Location = new System.Drawing.Point(156, 0);
            this.favouritesTab1.Name = "favouritesTab1";
            this.favouritesTab1.Size = new System.Drawing.Size(150, 70);
            this.favouritesTab1.TabIndex = 1;
            // 
            // watchListTab1
            // 
            this.watchListTab1.Location = new System.Drawing.Point(312, 0);
            this.watchListTab1.Name = "watchListTab1";
            this.watchListTab1.Size = new System.Drawing.Size(150, 70);
            this.watchListTab1.TabIndex = 2;
            // 
            // usernameTab1
            // 
            this.usernameTab1.Location = new System.Drawing.Point(468, 0);
            this.usernameTab1.Name = "usernameTab1";
            this.usernameTab1.Size = new System.Drawing.Size(150, 70);
            this.usernameTab1.TabIndex = 3;
            // 
            // tabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "tabs";
            this.Size = new System.Drawing.Size(618, 70);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private watchListTab watchListTab1;
        private favouritesTab favouritesTab1;
        private homeTab homeTab1;
        private usernameTab usernameTab1;
    }
}
