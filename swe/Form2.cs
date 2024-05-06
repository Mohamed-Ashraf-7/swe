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
    public partial class Form2 : Form
    {
        string ordb = "Data source =orcl; User Id=hr;Password=hr;";
        OracleConnection conn;
        public static Form2 instance;
        public Form2()
        {
            InitializeComponent();
            instance= this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECT USERID FROM USERS";
            c.CommandType = CommandType.Text;
            OracleDataReader rd = c.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd["USERID"]);
            }
            rd.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT EMAIL,PASSWORD,FIRSTNAME,LASTNAME,ROLE from USERS where USERID= :id";
            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            cmd.CommandType = CommandType.Text;

            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd[0].ToString();
                textBox2.Text = rd[1].ToString();
                textBox3.Text = rd[2].ToString();
                textBox4.Text = rd[3].ToString();
                textBox5.Text = rd[4].ToString();
            }
            rd.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO USERS (USERID, EMAIL, PASSWORD, FIRSTNAME, LASTNAME, ROLE) " +
                                  "VALUES (:id, :email, :password, :FName, :LName, :Role)";
                cmd.Parameters.Add("id", comboBox1.Text);
                cmd.Parameters.Add("email", textBox1.Text);
                cmd.Parameters.Add("password", textBox2.Text);
                cmd.Parameters.Add("FName", textBox3.Text);
                cmd.Parameters.Add("LName", textBox4.Text);
                cmd.Parameters.Add("Role", textBox5.Text);

                cmd.CommandType = CommandType.Text;

                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    comboBox1.Items.Add(comboBox1.Text);
                    MessageBox.Show("User Inserted");
                }
            }
            catch (OracleException ex)
            {
                // Handle duplicate USERID error
                if (ex.Number == 1) // ORA-00001: unique constraint violated
                {
                    MessageBox.Show("Error: USERID already exists. Please choose a different USERID.");
                }
                else
                {
                    // Handle other Oracle errors
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
