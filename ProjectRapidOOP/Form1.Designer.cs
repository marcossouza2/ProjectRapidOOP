namespace ProjectRapidOOP
{
    partial class Form1
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
            this.lblPlayerHp = new System.Windows.Forms.Label();
            this.lblOpponentHp = new System.Windows.Forms.Label();
            this.btnAttack1 = new System.Windows.Forms.Button();
            this.btnAttack2 = new System.Windows.Forms.Button();
            this.btnAttack3 = new System.Windows.Forms.Button();
            this.btnAttack4 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerHp
            // 
            this.lblPlayerHp.AutoSize = true;
            this.lblPlayerHp.Location = new System.Drawing.Point(635, 281);
            this.lblPlayerHp.Name = "lblPlayerHp";
            this.lblPlayerHp.Size = new System.Drawing.Size(68, 16);
            this.lblPlayerHp.TabIndex = 0;
            this.lblPlayerHp.Text = "Player HP";
            // 
            // lblOpponentHp
            // 
            this.lblOpponentHp.AutoSize = true;
            this.lblOpponentHp.Location = new System.Drawing.Point(26, 164);
            this.lblOpponentHp.Name = "lblOpponentHp";
            this.lblOpponentHp.Size = new System.Drawing.Size(84, 16);
            this.lblOpponentHp.TabIndex = 1;
            this.lblOpponentHp.Text = "OpponentHp";
            // 
            // btnAttack1
            // 
            this.btnAttack1.Location = new System.Drawing.Point(512, 321);
            this.btnAttack1.Name = "btnAttack1";
            this.btnAttack1.Size = new System.Drawing.Size(104, 41);
            this.btnAttack1.TabIndex = 3;
            this.btnAttack1.Text = "Attack 1";
            this.btnAttack1.UseVisualStyleBackColor = true;
            this.btnAttack1.Click += new System.EventHandler(this.btnAttack1_Click);
            // 
            // btnAttack2
            // 
            this.btnAttack2.Location = new System.Drawing.Point(638, 321);
            this.btnAttack2.Name = "btnAttack2";
            this.btnAttack2.Size = new System.Drawing.Size(104, 41);
            this.btnAttack2.TabIndex = 4;
            this.btnAttack2.Text = "Attack 2";
            this.btnAttack2.UseVisualStyleBackColor = true;
            this.btnAttack2.Click += new System.EventHandler(this.btnAttack2_Click);
            // 
            // btnAttack3
            // 
            this.btnAttack3.Location = new System.Drawing.Point(512, 368);
            this.btnAttack3.Name = "btnAttack3";
            this.btnAttack3.Size = new System.Drawing.Size(104, 41);
            this.btnAttack3.TabIndex = 5;
            this.btnAttack3.Text = "Attack 3";
            this.btnAttack3.UseVisualStyleBackColor = true;
            this.btnAttack3.Click += new System.EventHandler(this.btnAttack3_Click);
            // 
            // btnAttack4
            // 
            this.btnAttack4.Location = new System.Drawing.Point(638, 368);
            this.btnAttack4.Name = "btnAttack4";
            this.btnAttack4.Size = new System.Drawing.Size(104, 41);
            this.btnAttack4.TabIndex = 6;
            this.btnAttack4.Text = "Attack 4";
            this.btnAttack4.UseVisualStyleBackColor = true;
            this.btnAttack4.Click += new System.EventHandler(this.btnAttack4_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(29, 207);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(378, 202);
            this.txtMessage.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 131);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(638, 136);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(149, 131);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 442);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnAttack4);
            this.Controls.Add(this.btnAttack3);
            this.Controls.Add(this.btnAttack2);
            this.Controls.Add(this.btnAttack1);
            this.Controls.Add(this.lblOpponentHp);
            this.Controls.Add(this.lblPlayerHp);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerHp;
        private System.Windows.Forms.Label lblOpponentHp;
        private System.Windows.Forms.Button btnAttack1;
        private System.Windows.Forms.Button btnAttack2;
        private System.Windows.Forms.Button btnAttack3;
        private System.Windows.Forms.Button btnAttack4;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

