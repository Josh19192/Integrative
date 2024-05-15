namespace Child_vaccine
{
    partial class Vaccines
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvVaccines = new DataGridView();
            tbxVacName = new TextBox();
            tbxVacbrand = new TextBox();
            dtpAdded = new DateTimePicker();
            nudDose = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            bindingSource1 = new BindingSource(components);
            label1 = new Label();
            tbxSearch = new TextBox();
            tbxId = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCancel = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVaccines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dgvVaccines
            // 
            dgvVaccines.AllowDrop = true;
            dgvVaccines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVaccines.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVaccines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVaccines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVaccines.Location = new Point(110, 408);
            dgvVaccines.Name = "dgvVaccines";
            dgvVaccines.Size = new Size(953, 351);
            dgvVaccines.TabIndex = 0;
            dgvVaccines.CellClick += dgvVaccines_CellClick;
            dgvVaccines.CellContentClick += dgvVaccines_CellContentClick;
            // 
            // tbxVacName
            // 
            tbxVacName.Font = new Font("Arial Narrow", 12F);
            tbxVacName.Location = new Point(336, 83);
            tbxVacName.Name = "tbxVacName";
            tbxVacName.Size = new Size(239, 26);
            tbxVacName.TabIndex = 2;
            // 
            // tbxVacbrand
            // 
            tbxVacbrand.Font = new Font("Arial Narrow", 12F);
            tbxVacbrand.Location = new Point(336, 157);
            tbxVacbrand.Name = "tbxVacbrand";
            tbxVacbrand.Size = new Size(239, 26);
            tbxVacbrand.TabIndex = 3;
            // 
            // dtpAdded
            // 
            dtpAdded.Font = new Font("Arial Narrow", 12F);
            dtpAdded.Format = DateTimePickerFormat.Short;
            dtpAdded.Location = new Point(643, 157);
            dtpAdded.Name = "dtpAdded";
            dtpAdded.Size = new Size(172, 26);
            dtpAdded.TabIndex = 5;
            // 
            // nudDose
            // 
            nudDose.Font = new Font("Arial Narrow", 12F);
            nudDose.Location = new Point(643, 84);
            nudDose.Name = "nudDose";
            nudDose.Size = new Size(172, 26);
            nudDose.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 12F);
            label2.Location = new Point(336, 55);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 7;
            label2.Text = "VACCINE NAME ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 12F);
            label3.Location = new Point(643, 132);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 8;
            label3.Text = "DATE ADDED ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 12F);
            label4.Location = new Point(336, 132);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 9;
            label4.Text = "VACCINE BRAND ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 12F);
            label5.Location = new Point(643, 56);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 10;
            label5.Text = "DOSE ";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(27, 26, 94);
            btnAdd.ForeColor = SystemColors.ButtonFace;
            btnAdd.Location = new Point(442, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(237, 35);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F);
            label1.Location = new Point(106, 364);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 13;
            label1.Text = "SEARCH : ";
            // 
            // tbxSearch
            // 
            tbxSearch.Font = new Font("Arial Narrow", 12F);
            tbxSearch.Location = new Point(187, 361);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(565, 26);
            tbxSearch.TabIndex = 12;
            tbxSearch.TextChanged += tbxSearch_TextChanged;
            // 
            // tbxId
            // 
            tbxId.Font = new Font("Arial Narrow", 12F);
            tbxId.Location = new Point(187, 239);
            tbxId.Name = "tbxId";
            tbxId.Size = new Size(129, 26);
            tbxId.TabIndex = 14;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(585, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(182, 35);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(381, 230);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(182, 35);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(782, 273);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(182, 35);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(3, 123, 128);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(116, 35);
            button1.TabIndex = 100;
            button1.Text = "BACK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Vaccines
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 816);
            Controls.Add(button1);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(tbxId);
            Controls.Add(label1);
            Controls.Add(tbxSearch);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nudDose);
            Controls.Add(dtpAdded);
            Controls.Add(tbxVacbrand);
            Controls.Add(tbxVacName);
            Controls.Add(dgvVaccines);
            Name = "Vaccines";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vaccines";
            Load += Vaccines_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVaccines).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDose).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVaccines;
        private TextBox tbxVacName;
        private TextBox tbxVacbrand;
        private DateTimePicker dtpAdded;
        private NumericUpDown nudDose;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAdd;
        private BindingSource bindingSource1;
        private Label label1;
        private TextBox tbxSearch;
        private TextBox tbxId;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCancel;
        private Button button1;
    }
}