namespace FinalProject_MovieApp
{
    partial class StartingScreen
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
            this.startingLabel = new System.Windows.Forms.Label();
            this.startingLabel_2 = new System.Windows.Forms.Label();
            this.returningUser_btn = new System.Windows.Forms.Button();
            this.newUser_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.enter_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startingLabel
            // 
            this.startingLabel.AutoSize = true;
            this.startingLabel.Font = new System.Drawing.Font("Sans Serif Collection", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingLabel.ForeColor = System.Drawing.Color.Red;
            this.startingLabel.Location = new System.Drawing.Point(229, 148);
            this.startingLabel.Name = "startingLabel";
            this.startingLabel.Size = new System.Drawing.Size(1230, 236);
            this.startingLabel.TabIndex = 0;
            this.startingLabel.Text = "Movie Streams";
            this.startingLabel.Click += new System.EventHandler(this.startingLabel_Click);
            // 
            // startingLabel_2
            // 
            this.startingLabel_2.AutoSize = true;
            this.startingLabel_2.BackColor = System.Drawing.Color.Black;
            this.startingLabel_2.Font = new System.Drawing.Font("Sans Serif Collection", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startingLabel_2.ForeColor = System.Drawing.Color.Red;
            this.startingLabel_2.Location = new System.Drawing.Point(489, 384);
            this.startingLabel_2.Name = "startingLabel_2";
            this.startingLabel_2.Size = new System.Drawing.Size(646, 47);
            this.startingLabel_2.TabIndex = 1;
            this.startingLabel_2.Text = "Personalized Watch List, Favorites, and Trends";
            this.startingLabel_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // returningUser_btn
            // 
            this.returningUser_btn.AutoSize = true;
            this.returningUser_btn.BackColor = System.Drawing.Color.Red;
            this.returningUser_btn.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.returningUser_btn.Font = new System.Drawing.Font("Sans Serif Collection", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returningUser_btn.ForeColor = System.Drawing.Color.Black;
            this.returningUser_btn.Location = new System.Drawing.Point(497, 601);
            this.returningUser_btn.Name = "returningUser_btn";
            this.returningUser_btn.Size = new System.Drawing.Size(292, 72);
            this.returningUser_btn.TabIndex = 2;
            this.returningUser_btn.Text = "RETURNING USER";
            this.returningUser_btn.UseVisualStyleBackColor = false;
            this.returningUser_btn.Click += new System.EventHandler(this.returningUser_btn_Click);
            // 
            // newUser_btn
            // 
            this.newUser_btn.AutoSize = true;
            this.newUser_btn.BackColor = System.Drawing.Color.Red;
            this.newUser_btn.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.newUser_btn.Font = new System.Drawing.Font("Sans Serif Collection", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUser_btn.ForeColor = System.Drawing.Color.Black;
            this.newUser_btn.Location = new System.Drawing.Point(843, 601);
            this.newUser_btn.Name = "newUser_btn";
            this.newUser_btn.Size = new System.Drawing.Size(292, 72);
            this.newUser_btn.TabIndex = 3;
            this.newUser_btn.Text = "NEW USER";
            this.newUser_btn.UseVisualStyleBackColor = false;
            this.newUser_btn.Click += new System.EventHandler(this.newUser_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Segoe Fluent Icons", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(500, 744);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 27);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe Fluent Icons", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(843, 744);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(292, 26);
            this.textBox.TabIndex = 5;
            this.textBox.Visible = false;
            // 
            // enter_btn
            // 
            this.enter_btn.AutoSize = true;
            this.enter_btn.BackColor = System.Drawing.Color.Red;
            this.enter_btn.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.enter_btn.Font = new System.Drawing.Font("Sans Serif Collection", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enter_btn.ForeColor = System.Drawing.Color.Black;
            this.enter_btn.Location = new System.Drawing.Point(720, 785);
            this.enter_btn.Name = "enter_btn";
            this.enter_btn.Size = new System.Drawing.Size(200, 49);
            this.enter_btn.TabIndex = 6;
            this.enter_btn.Text = "Enter";
            this.enter_btn.UseVisualStyleBackColor = false;
            this.enter_btn.Click += new System.EventHandler(this.enter_btn_Click);
            // 
            // StartingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1632, 854);
            this.Controls.Add(this.enter_btn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newUser_btn);
            this.Controls.Add(this.returningUser_btn);
            this.Controls.Add(this.startingLabel_2);
            this.Controls.Add(this.startingLabel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "StartingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Streams";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startingLabel;
        private System.Windows.Forms.Label startingLabel_2;
        private System.Windows.Forms.Button returningUser_btn;
        private System.Windows.Forms.Button newUser_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button enter_btn;
    }
}