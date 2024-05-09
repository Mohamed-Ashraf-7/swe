using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe
{
    public partial class Form7 : Form
    {
        CrystalReport2 CR;
        public static Form7 instance;
        public Form7()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR;
        }
    }
}
