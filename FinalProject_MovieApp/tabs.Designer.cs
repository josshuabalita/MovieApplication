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
            this.usernameTab1 = new FinalProject_MovieApp.usernameTab();
            this.watchListTab1 = new FinalProject_MovieApp.watchListTab();
            this.favouritesTab1 = new FinalProject_MovieApp.favouritesTab();
            this.homeTab1 = new FinalProject_MovieApp.homeTab();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 86);
            this.panel1.TabIndex = 0;
            // 
            // usernameTab1
            // 
            this.usernameTab1.Location = new System.Drawing.Point(624, 0);
            this.usernameTab1.Margin = new System.Windows.Forms.Padding(5);
            this.usernameTab1.Name = "usernameTab1";
            this.usernameTab1.Size = new System.Drawing.Size(200, 86);
            this.usernameTab1.TabIndex = 3;
            this.usernameTab1.Load += new System.EventHandler(this.usernameTab1_Load);
            // 
            // watchListTab1
            // 
            this.watchListTab1.Location = new System.Drawing.Point(416, 0);
            this.watchListTab1.Margin = new System.Windows.Forms.Padding(5);
            this.watchListTab1.Name = "watchListTab1";
            this.watchListTab1.Size = new System.Drawing.Size(200, 86);
            this.watchListTab1.TabIndex = 2;
            // 
            // favouritesTab1
            // 
            this.favouritesTab1.Location = new System.Drawing.Point(208, 0);
            this.favouritesTab1.Margin = new System.Windows.Forms.Padding(5);
            this.favouritesTab1.Name = "favouritesTab1";
            this.favouritesTab1.Size = new System.Drawing.Size(200, 86);
            this.favouritesTab1.TabIndex = 1;
            // 
            // homeTab1
            // 
            this.homeTab1.Location = new System.Drawing.Point(0, 0);
            this.homeTab1.Margin = new System.Windows.Forms.Padding(5);
            this.homeTab1.Name = "homeTab1";
            this.homeTab1.Size = new System.Drawing.Size(200, 86);
            this.homeTab1.TabIndex = 0;
            // 
            // tabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "tabs";
            this.Size = new System.Drawing.Size(824, 86);
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
