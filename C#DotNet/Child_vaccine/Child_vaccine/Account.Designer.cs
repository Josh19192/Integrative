namespace Child_vaccine
{
    partial class Account
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
            label4 = new Label();
            label2 = new Label();
            tbxPassword = new TextBox();
            tbxUsername = new TextBox();
            label1 = new Label();
            tbxCon = new TextBox();
            btnCreate = new Button();
            button2 = new Button();
            checkBoxPass = new CheckBox();
            checkBoxCon = new CheckBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F);
            label4.Location = new Point(202, 214);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 13;
            label4.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F);
            label2.Location = new Point(202, 153);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 12;
            label2.Text = "Username";
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Arial Narrow", 12F);
            tbxPassword.Location = new Point(202, 237);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(239, 26);
            tbxPassword.TabIndex = 11;
            tbxPassword.UseSystemPasswordChar = true;
            // 
            // tbxUsername
            // 
            tbxUsername.Font = new Font("Arial Narrow", 12F);
            tbxUsername.Location = new Point(202, 176);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(239, 26);
            tbxUsername.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F);
            label1.Location = new Point(204, 306);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 15;
            label1.Text = "Confirm Password";
            // 
            // tbxCon
            // 
            tbxCon.Font = new Font("Arial Narrow", 12F);
            tbxCon.Location = new Point(202, 329);
            tbxCon.Name = "tbxCon";
            tbxCon.Size = new Size(239, 26);
            tbxCon.TabIndex = 14;
            tbxCon.UseSystemPasswordChar = true;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(27, 26, 94);
            btnCreate.ForeColor = SystemColors.ButtonFace;
            btnCreate.Location = new Point(199, 433);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(237, 35);
            btnCreate.TabIndex = 98;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnAdd_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 123, 128);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(116, 35);
            button2.TabIndex = 101;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // checkBoxPass
            // 
            checkBoxPass.AutoSize = true;
            checkBoxPass.Location = new Point(208, 266);
            checkBoxPass.Name = "checkBoxPass";
            checkBoxPass.Size = new Size(55, 19);
            checkBoxPass.TabIndex = 102;
            checkBoxPass.Text = "Show";
            checkBoxPass.UseVisualStyleBackColor = true;
            checkBoxPass.CheckedChanged += checkBoxPass_CheckedChanged;
            // 
            // checkBoxCon
            // 
            checkBoxCon.AutoSize = true;
            checkBoxCon.Location = new Point(208, 357);
            checkBoxCon.Name = "checkBoxCon";
            checkBoxCon.Size = new Size(55, 19);
            checkBoxCon.TabIndex = 103;
            checkBoxCon.Text = "Show";
            checkBoxCon.UseVisualStyleBackColor = true;
            checkBoxCon.CheckedChanged += checkBoxCon_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.LogInLogo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(256, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(127, 110);
            pictureBox1.TabIndex = 104;
            pictureBox1.TabStop = false;
            // 
            // Account
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 511);
            Controls.Add(pictureBox1);
            Controls.Add(checkBoxCon);
            Controls.Add(checkBoxPass);
            Controls.Add(button2);
            Controls.Add(btnCreate);
            Controls.Add(label1);
            Controls.Add(tbxCon);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            Name = "Account";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account";
            Load += Account_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label2;
        private TextBox tbxPassword;
        private TextBox tbxUsername;
        private Label label1;
        private TextBox tbxCon;
        private Button btnCreate;
        private Button button2;
        private CheckBox checkBoxPass;
        private CheckBox checkBoxCon;
        private PictureBox pictureBox1;
    }
}