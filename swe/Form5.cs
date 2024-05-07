using Oracle.DataAccess.Client;
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
    public partial class Form5 : Form
    {
        string ordb = "Data source =orcl; User Id=hr;Password=hr;";
        OracleConnection conn;
        public static Form5 instance;
        public Form5()
        {
            InitializeComponent();
            instance= this;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Establish connection
            conn = new OracleConnection(ordb);
            conn.Open();

            // Create command to call stored procedure
            OracleCommand cmd = new OracleCommand("GetArticle", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameters
            cmd.Parameters.Add("id", textBox1.Text);//).Value = textBox1.Text;
            cmd.Parameters.Add("Title", OracleDbType.RefCursor, ParameterDirection.Output);

            try
            {
                // Execute stored procedure and read data
                using (OracleDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        comboBox1.Items.Add(rd[0]);
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}
