using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatusSave
{
    public partial class Form1 : Form
    {
        //common (single) object of status calss
        StatusClass m_statusClass;
        public Form1()
        {
            InitializeComponent();

            //creating this object only once while software starts
            // we can even serialize- deserialize this object 
            m_statusClass = new StatusClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //passing common (single) object of status class in this form 
            FrmSaveCSV frmSaveCSV = new FrmSaveCSV(m_statusClass);
            frmSaveCSV.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Status.dat";
            if (File.Exists(fileName))
            {
                Stream s = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IFormatter f1 = new BinaryFormatter();
                try
                {
                    m_statusClass = (StatusClass)f1.Deserialize(s);
                }
                catch
                {
                    s.Close();
                    m_statusClass = new StatusClass();
                }
                s.Close();
            }
            else
                m_statusClass = new StatusClass();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileName = "Status.dat";
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (Stream s = new FileStream("Status.dat", FileMode.Create))
            {
                IFormatter f2 = new BinaryFormatter();
                f2.Serialize(s, m_statusClass);
                s.Close();
                s.Dispose();
            }
        }
    }
}
