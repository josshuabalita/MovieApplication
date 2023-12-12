namespace FinalProject_MovieApp
{
    partial class favouritesTab
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
            this.faveTab = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.faveTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // faveTab
            // 
            this.faveTab.BackColor = System.Drawing.Color.Red;
            this.faveTab.Controls.Add(this.label1);
            this.faveTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faveTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faveTab.Location = new System.Drawing.Point(0, 0);
            this.faveTab.Name = "faveTab";
            this.faveTab.Size = new System.Drawing.Size(150, 70);
            this.faveTab.TabIndex = 1;
            this.faveTab.Click += new System.EventHandler(this.faveTab_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "FAVOURITES";
            // 
            // favouritesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.faveTab);
            this.Name = "favouritesTab";
            this.Size = new System.Drawing.Size(150, 70);
            this.faveTab.ResumeLayout(false);
            this.faveTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel faveTab;
        private System.Windows.Forms.Label label1;
    }
}
