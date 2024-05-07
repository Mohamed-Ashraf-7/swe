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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Establish connection
            using (conn = new OracleConnection(ordb))
            {
                conn.Open();

                // Create command to call stored procedure
                OracleCommand cmd = new OracleCommand("GetArticleDetails", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters
                cmd.Parameters.Add("title", OracleDbType.Varchar2).Value = textBox1.Text;
                cmd.Parameters.Add("content", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("AuthorID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("PublishDate", OracleDbType.Date).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Views", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Rating", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Review", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("CreationDate", OracleDbType.Date).Direction = ParameterDirection.Output;

                try
                {
                    // Execute the stored procedure
                    cmd.ExecuteNonQuery();

                    // Retrieve and handle output parameter values
                    if (cmd.Parameters["content"].Value != null)
                    {
                        textBox2.Text = cmd.Parameters["content"].Value.ToString();
                    }
                    if (cmd.Parameters["AuthorID"].Value != null)
                    {
                        textBox3.Text = cmd.Parameters["AuthorID"].Value.ToString();
                    }
                    if (cmd.Parameters["PublishDate"].Value != null)
                    {
                        textBox4.Text = cmd.Parameters["PublishDate"].Value.ToString();
                    }
                    if (cmd.Parameters["Views"].Value != null)
                    {
                        textBox5.Text = cmd.Parameters["Views"].Value.ToString();
                    }
                    if (cmd.Parameters["Rating"].Value != null)
                    {
                        textBox6.Text = cmd.Parameters["Rating"].Value.ToString();
                    }
                    if (cmd.Parameters["Review"].Value != null)
                    {
                        textBox7.Text = cmd.Parameters["Review"].Value.ToString();
                    }
                    if (cmd.Parameters["CreationDate"].Value != null)
                    {
                        textBox8.Text = cmd.Parameters["CreationDate"].Value.ToString();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
