using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace swe
{
    public partial class Form4 : Form
    {
        string ordb = "Data source =orcl; User Id=hr;Password=hr;";
        OracleConnection conn;
        public static Form4 instance;
        public Form4()
        {
            InitializeComponent();
            instance= this;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
