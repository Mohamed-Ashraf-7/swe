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
    public partial class Form3 : Form
    {
        string ordb = "Data source =orcl; User Id=hr;Password=hr;";
        OracleConnection conn;
        public static Form3 instance;
        public Form3()
        {
            InitializeComponent();
            instance= this;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECT AUTHORID FROM AUTHORS ";
            c.CommandType = CommandType.Text;
            OracleDataReader rd = c.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["AUTHORID"]);
            }
            rd.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT BIO from AUTHORS where AUTHORID= :id";
            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            cmd.CommandType = CommandType.Text;

            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd[0].ToString();
            }
            rd.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
