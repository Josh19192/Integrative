namespace Child_vaccine
{
    partial class Shot_records
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
            label1 = new Label();
            tbxSearch = new TextBox();
            dgvRecords = new DataGridView();
            btnCancel = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            tbxId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpShotDate = new DateTimePicker();
            label6 = new Label();
            tbxRemarks = new TextBox();
            tbxChildName = new Label();
            cbxVacName = new ComboBox();
            button2 = new Button();
            cbxDoseNo = new ComboBox();
            tbxChildId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F);
            label1.Location = new Point(108, 327);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 16;
            label1.Text = "SEARCH : ";
            // 
            // tbxSearch
            // 
            tbxSearch.Font = new Font("Arial Narrow", 12F);
            tbxSearch.Location = new Point(187, 324);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(565, 26);
            tbxSearch.TabIndex = 15;
            tbxSearch.TextChanged += textBox1_TextChanged;
            // 
            // dgvRecords
            // 
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.Location = new Point(107, 370);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.Size = new Size(966, 351);
            dgvRecords.TabIndex = 14;
            dgvRecords.CellClick += dgvRecords_CellClick;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(766, 259);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(182, 35);
            btnCancel.TabIndex = 32;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(365, 216);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(182, 35);
            btnUpdate.TabIndex = 31;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(569, 216);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(182, 35);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbxId
            // 
            tbxId.Font = new Font("Arial Narrow", 12F);
            tbxId.Location = new Point(204, 216);
            tbxId.Name = "tbxId";
            tbxId.Size = new Size(129, 26);
            tbxId.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F);
            label5.Location = new Point(471, 32);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 27;
            label5.Text = "DOSE NO.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F);
            label4.Location = new Point(164, 106);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 26;
            label4.Text = "VACCINE NAME ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F);
            label3.Location = new Point(471, 106);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 25;
            label3.Text = "SHOT DATE";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F);
            label2.Location = new Point(164, 31);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 24;
            label2.Text = "CHILD NAME ";
            // 
            // dtpShotDate
            // 
            dtpShotDate.Font = new Font("Arial Narrow", 12F);
            dtpShotDate.Format = DateTimePickerFormat.Short;
            dtpShotDate.Location = new Point(471, 133);
            dtpShotDate.Name = "dtpShotDate";
            dtpShotDate.Size = new Size(172, 26);
            dtpShotDate.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 12F);
            label6.Location = new Point(720, 32);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 34;
            label6.Text = "REMARKS";
            // 
            // tbxRemarks
            // 
            tbxRemarks.Font = new Font("Arial Narrow", 12F);
            tbxRemarks.Location = new Point(720, 60);
            tbxRemarks.Multiline = true;
            tbxRemarks.Name = "tbxRemarks";
            tbxRemarks.Size = new Size(319, 99);
            tbxRemarks.TabIndex = 33;
            // 
            // tbxChildName
            // 
            tbxChildName.AutoSize = true;
            tbxChildName.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxChildName.Location = new Point(164, 63);
            tbxChildName.Name = "tbxChildName";
            tbxChildName.Size = new Size(114, 19);
            tbxChildName.TabIndex = 35;
            tbxChildName.Text = "CHILD NAME ";
            // 
            // cbxVacName
            // 
            cbxVacName.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxVacName.FormattingEnabled = true;
            cbxVacName.Location = new Point(164, 133);
            cbxVacName.Name = "cbxVacName";
            cbxVacName.Size = new Size(201, 24);
            cbxVacName.TabIndex = 50;
            cbxVacName.SelectedIndexChanged += cbxVacName_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(3, 123, 128);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(125, 35);
            button2.TabIndex = 109;
            button2.Text = "BACK";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // cbxDoseNo
            // 
            cbxDoseNo.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxDoseNo.FormattingEnabled = true;
            cbxDoseNo.Location = new Point(471, 63);
            cbxDoseNo.Name = "cbxDoseNo";
            cbxDoseNo.Size = new Size(172, 24);
            cbxDoseNo.TabIndex = 110;
            // 
            // tbxChildId
            // 
            tbxChildId.Font = new Font("Arial Narrow", 12F);
            tbxChildId.Location = new Point(204, 248);
            tbxChildId.Name = "tbxChildId";
            tbxChildId.Size = new Size(129, 26);
            tbxChildId.TabIndex = 111;
            tbxChildId.TextChanged += textBox1_TextChanged_1;
            // 
            // Shot_records
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 747);
            Controls.Add(tbxChildId);
            Controls.Add(cbxDoseNo);
            Controls.Add(button2);
            Controls.Add(cbxVacName);
            Controls.Add(tbxChildName);
            Controls.Add(label6);
            Controls.Add(tbxRemarks);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(tbxId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpShotDate);
            Controls.Add(label1);
            Controls.Add(tbxSearch);
            Controls.Add(dgvRecords);
            Name = "Shot_records";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shot_records";
            Load += Shot_records_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbxSearch;
        private DataGridView dgvRecords;
        private Button btnCancel;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox tbxId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpShotDate;
        private Label label6;
        private TextBox tbxRemarks;
        private Label tbxChildName;
        private ComboBox cbxVacName;
        private Button button2;
        private ComboBox cbxDoseNo;
        private TextBox tbxChildId;
    }
}