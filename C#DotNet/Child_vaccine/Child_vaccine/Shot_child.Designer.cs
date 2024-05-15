namespace Child_vaccine
{
    partial class Shot_child
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label26 = new Label();
            textBox19 = new TextBox();
            dgvChildren = new DataGridView();
            cbxVacName = new ComboBox();
            tbxChildName = new Label();
            label6 = new Label();
            tbxRemarks = new TextBox();
            btnCancel = new Button();
            tbxChildId = new TextBox();
            btnAdd = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpShotDate = new DateTimePicker();
            cbxDoseNo = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChildren).BeginInit();
            SuspendLayout();
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Arial Narrow", 12F);
            label26.Location = new Point(70, 382);
            label26.Name = "label26";
            label26.Size = new Size(75, 20);
            label26.TabIndex = 90;
            label26.Text = "SEARCH : ";
            // 
            // textBox19
            // 
            textBox19.Font = new Font("Arial Narrow", 12F);
            textBox19.Location = new Point(151, 379);
            textBox19.Name = "textBox19";
            textBox19.Size = new Size(565, 26);
            textBox19.TabIndex = 89;
            // 
            // dgvChildren
            // 
            dgvChildren.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChildren.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChildren.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChildren.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChildren.Location = new Point(72, 428);
            dgvChildren.Name = "dgvChildren";
            dgvChildren.RowHeadersWidth = 51;
            dgvChildren.Size = new Size(1101, 345);
            dgvChildren.TabIndex = 88;
            dgvChildren.CellClick += dgvChildren_CellClick;
            // 
            // cbxVacName
            // 
            cbxVacName.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxVacName.FormattingEnabled = true;
            cbxVacName.Location = new Point(250, 159);
            cbxVacName.Name = "cbxVacName";
            cbxVacName.Size = new Size(201, 28);
            cbxVacName.TabIndex = 105;
            cbxVacName.SelectedIndexChanged += cbxVacName_SelectedIndexChanged;
            // 
            // tbxChildName
            // 
            tbxChildName.AutoSize = true;
            tbxChildName.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxChildName.Location = new Point(250, 89);
            tbxChildName.Name = "tbxChildName";
            tbxChildName.Size = new Size(134, 22);
            tbxChildName.TabIndex = 104;
            tbxChildName.Text = "CHILD NAME ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 12F);
            label6.Location = new Point(741, 60);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 103;
            label6.Text = "REMARKS";
            // 
            // tbxRemarks
            // 
            tbxRemarks.Font = new Font("Arial Narrow", 12F);
            tbxRemarks.Location = new Point(741, 88);
            tbxRemarks.Multiline = true;
            tbxRemarks.Name = "tbxRemarks";
            tbxRemarks.Size = new Size(319, 99);
            tbxRemarks.TabIndex = 102;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(479, 288);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(237, 35);
            btnCancel.TabIndex = 101;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbxChildId
            // 
            tbxChildId.Font = new Font("Arial Narrow", 12F);
            tbxChildId.Location = new Point(279, 208);
            tbxChildId.Name = "tbxChildId";
            tbxChildId.Size = new Size(129, 26);
            tbxChildId.TabIndex = 98;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(27, 26, 94);
            btnAdd.ForeColor = SystemColors.ButtonFace;
            btnAdd.Location = new Point(479, 247);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(237, 35);
            btnAdd.TabIndex = 97;
            btnAdd.Text = "ADD SHOT";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F);
            label5.Location = new Point(516, 60);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 96;
            label5.Text = "DOSE NO.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F);
            label4.Location = new Point(250, 132);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 95;
            label4.Text = "VACCINE NAME ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F);
            label3.Location = new Point(516, 134);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 94;
            label3.Text = "SHOT DATE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F);
            label2.Location = new Point(250, 57);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 93;
            label2.Text = "CHILD NAME ";
            // 
            // dtpShotDate
            // 
            dtpShotDate.Font = new Font("Arial Narrow", 12F);
            dtpShotDate.Format = DateTimePickerFormat.Short;
            dtpShotDate.Location = new Point(516, 161);
            dtpShotDate.Name = "dtpShotDate";
            dtpShotDate.Size = new Size(172, 26);
            dtpShotDate.TabIndex = 91;
            // 
            // cbxDoseNo
            // 
            cbxDoseNo.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxDoseNo.FormattingEnabled = true;
            cbxDoseNo.Location = new Point(516, 91);
            cbxDoseNo.Name = "cbxDoseNo";
            cbxDoseNo.Size = new Size(172, 28);
            cbxDoseNo.TabIndex = 106;
            cbxDoseNo.SelectedIndexChanged += cbxDoseNo_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 123, 128);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(125, 35);
            button2.TabIndex = 108;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Shot_child
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 796);
            Controls.Add(button2);
            Controls.Add(cbxDoseNo);
            Controls.Add(cbxVacName);
            Controls.Add(tbxChildName);
            Controls.Add(label6);
            Controls.Add(tbxRemarks);
            Controls.Add(btnCancel);
            Controls.Add(tbxChildId);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpShotDate);
            Controls.Add(label26);
            Controls.Add(textBox19);
            Controls.Add(dgvChildren);
            Name = "Shot_child";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shot_child";
            Load += Shot_child_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChildren).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label26;
        private TextBox textBox19;
        private DataGridView dgvChildren;
        private ComboBox cbxVacName;
        private Label tbxChildName;
        private Label label6;
        private TextBox tbxRemarks;
        private Button btnCancel;
        private TextBox tbxChildId;
        private Button btnAdd;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpShotDate;
        private ComboBox cbxDoseNo;
        private Button button2;
    }
}