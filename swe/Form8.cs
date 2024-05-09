using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace swe
{
    public partial class Form8 : Form
    {
        CrystalReport4 C;
        public static Form8 instance;
        public Form8()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            C = new CrystalReport4();
            foreach (ParameterDiscreteValue v in C.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = C;
            C.SetParameterValue(0, comboBox1.Text);
        }
    }
}
