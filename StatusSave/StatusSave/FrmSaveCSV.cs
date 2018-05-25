using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatusSave
{
    public partial class FrmSaveCSV : Form
    {
        private StatusClass m_statusClass;
        public FrmSaveCSV(StatusClass statusClass)
        {
            InitializeComponent();
            m_statusClass = statusClass;
        }

        private void FrmSaveCSV_Load(object sender, EventArgs e)
        {
            LoadStaus();
        }

        private void FrmSaveCSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveStatus();
        }

        private void LoadStaus()
        {
            this.checkBox1.Checked = m_statusClass.Chkbox1Checked;
            this.checkBox2.Checked = m_statusClass.Chkbox2Checked;
            //same way load other controls
        }
        private void SaveStatus()
        {
            m_statusClass.Chkbox1Checked = this.checkBox1.Checked;
            m_statusClass.Chkbox2Checked = this.checkBox2.Checked;
        }
    }
}
