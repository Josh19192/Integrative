namespace Child_vaccine
{
    partial class dashboard
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
            menuStrip1 = new MenuStrip();
            dASHBOARDToolStripMenuItem = new ToolStripMenuItem();
            cHILDRENToolStripMenuItem = new ToolStripMenuItem();
            aDDVACCINEToolStripMenuItem = new ToolStripMenuItem();
            sHOTRECORDSToolStripMenuItem = new ToolStripMenuItem();
            mANAGECHILDRENToolStripMenuItem = new ToolStripMenuItem();
            aCCOUNTToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.Items.AddRange(new ToolStripItem[] { dASHBOARDToolStripMenuItem, mANAGECHILDRENToolStripMenuItem, cHILDRENToolStripMenuItem, aDDVACCINEToolStripMenuItem, sHOTRECORDSToolStripMenuItem, aCCOUNTToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(971, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // dASHBOARDToolStripMenuItem
            // 
            dASHBOARDToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            dASHBOARDToolStripMenuItem.Name = "dASHBOARDToolStripMenuItem";
            dASHBOARDToolStripMenuItem.Size = new Size(133, 29);
            dASHBOARDToolStripMenuItem.Text = "DASHBOARD";
            // 
            // cHILDRENToolStripMenuItem
            // 
            cHILDRENToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            cHILDRENToolStripMenuItem.Name = "cHILDRENToolStripMenuItem";
            cHILDRENToolStripMenuItem.Size = new Size(127, 29);
            cHILDRENToolStripMenuItem.Text = "SHOT CHILD";
            cHILDRENToolStripMenuItem.Click += cHILDRENToolStripMenuItem_Click;
            // 
            // aDDVACCINEToolStripMenuItem
            // 
            aDDVACCINEToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            aDDVACCINEToolStripMenuItem.Name = "aDDVACCINEToolStripMenuItem";
            aDDVACCINEToolStripMenuItem.Size = new Size(182, 29);
            aDDVACCINEToolStripMenuItem.Text = "MANAGE VACCINE";
            aDDVACCINEToolStripMenuItem.Click += aDDVACCINEToolStripMenuItem_Click;
            // 
            // sHOTRECORDSToolStripMenuItem
            // 
            sHOTRECORDSToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            sHOTRECORDSToolStripMenuItem.Name = "sHOTRECORDSToolStripMenuItem";
            sHOTRECORDSToolStripMenuItem.Size = new Size(155, 29);
            sHOTRECORDSToolStripMenuItem.Text = "SHOT RECORDS";
            sHOTRECORDSToolStripMenuItem.Click += sHOTRECORDSToolStripMenuItem_Click;
            // 
            // mANAGECHILDRENToolStripMenuItem
            // 
            mANAGECHILDRENToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            mANAGECHILDRENToolStripMenuItem.Name = "mANAGECHILDRENToolStripMenuItem";
            mANAGECHILDRENToolStripMenuItem.Size = new Size(194, 29);
            mANAGECHILDRENToolStripMenuItem.Text = "MANAGE CHILDREN";
            mANAGECHILDRENToolStripMenuItem.Click += mANAGECHILDRENToolStripMenuItem_Click_1;
            // 
            // aCCOUNTToolStripMenuItem
            // 
            aCCOUNTToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            aCCOUNTToolStripMenuItem.Name = "aCCOUNTToolStripMenuItem";
            aCCOUNTToolStripMenuItem.Size = new Size(109, 29);
            aCCOUNTToolStripMenuItem.Text = "ACCOUNT";
            aCCOUNTToolStripMenuItem.Click += aCCOUNTToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(567, 214);
            label1.Name = "label1";
            label1.Size = new Size(308, 120);
            label1.TabIndex = 1;
            label1.Text = "CHILD VACCINE \r\nINFORMATION\r\nSYSTEM";
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.AdobeStock_321996582_scaled;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(971, 559);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "dashboard";
            Load += dashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dASHBOARDToolStripMenuItem;
        private ToolStripMenuItem cHILDRENToolStripMenuItem;
        private ToolStripMenuItem aDDVACCINEToolStripMenuItem;
        private ToolStripMenuItem sHOTRECORDSToolStripMenuItem;
        private ToolStripMenuItem aCCOUNTToolStripMenuItem;
        private ToolStripMenuItem mANAGECHILDRENToolStripMenuItem;
        private Label label1;
    }
}