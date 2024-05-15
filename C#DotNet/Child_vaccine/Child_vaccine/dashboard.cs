using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Child_vaccine
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mANAGECHILDRENToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mANAGECHILDRENToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Children cd = new Children();
            this.Hide();
            cd.Show();

        }

        private void aDDVACCINEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vaccines vcs = new Vaccines();
            this.Hide();
            vcs.Show();
        }

        private void sHOTRECORDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shot_records sr = new Shot_records();
            this.Hide();
            sr.Show();
        }

        private void cHILDRENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shot_child sc = new Shot_child();
            this.Hide();
            sc.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void aCCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account ac = new Account();
            this.Hide();
            ac.Show();
        }
    }
}
