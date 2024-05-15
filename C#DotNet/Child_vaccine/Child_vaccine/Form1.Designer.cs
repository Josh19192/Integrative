namespace Child_vaccine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbxPassword = new TextBox();
            tbxUsername = new TextBox();
            pictureBox1 = new PictureBox();
            btnLogin = new Button();
            checkBoxCon = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Arial Narrow", 12F);
            tbxPassword.Location = new Point(205, 296);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PlaceholderText = "Password";
            tbxPassword.Size = new Size(193, 26);
            tbxPassword.TabIndex = 1;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // tbxUsername
            // 
            tbxUsername.Font = new Font("Arial Narrow", 12F);
            tbxUsername.Location = new Point(205, 243);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.PlaceholderText = "Username";
            tbxUsername.Size = new Size(193, 26);
            tbxUsername.TabIndex = 2;
            tbxUsername.TextChanged += textBox2_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.LogInLogo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(236, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 110);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(27, 26, 94);
            btnLogin.Font = new Font("Gadugi", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(171, 387);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(256, 38);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // checkBoxCon
            // 
            checkBoxCon.AutoSize = true;
            checkBoxCon.Location = new Point(208, 325);
            checkBoxCon.Name = "checkBoxCon";
            checkBoxCon.Size = new Size(55, 19);
            checkBoxCon.TabIndex = 104;
            checkBoxCon.Text = "Show";
            checkBoxCon.UseVisualStyleBackColor = true;
            checkBoxCon.CheckedChanged += checkBoxCon_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 522);
            Controls.Add(checkBoxCon);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox1);
            Controls.Add(tbxUsername);
            Controls.Add(tbxPassword);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbxPassword;
        private TextBox tbxUsername;
        private PictureBox pictureBox1;
        private Button btnLogin;
        private CheckBox checkBoxCon;
    }
}
