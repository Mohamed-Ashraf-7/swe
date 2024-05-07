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
    public partial class Form6 : Form
    {
        DataSet data;
        OracleDataAdapter adapter;
        OracleConnection conn;
        OracleCommandBuilder builder;
        public static Form6 instance;
        public Form6()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn = "Data source =orcl; User Id=hr;Password=hr;";
            string cmdstr = @"SELECT TITLE,PUBLISHEDDATE,ARTICLEID 
                            FROM USERS us,AUTHORS au,ARTICLES ar
                            WHERE us.USERID = au.USERID AND
                            ar.AUTHORID = au.AUTHORID AND
                            us.FIRSTNAME = :name";
            adapter = new OracleDataAdapter(cmdstr, conn);
            adapter.SelectCommand.Parameters.Add("id", textBox1.Text);
            data = new DataSet();
            adapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialize the OracleCommandBuilder with the adapter
                builder = new OracleCommandBuilder(adapter);

                // Before updating, check the data for null values in the ARTICLEID column
                DataTable table = data.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        // If the ARTICLEID column is null or empty, handle it accordingly
                        if (row.IsNull("ARTICLEID"))
                        {
                            MessageBox.Show("ARTICLEID cannot be null. Please provide a valid value.", "Data Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Update the data in the database
                adapter.Update(table);

                // Inform the user that the update was successful
                MessageBox.Show("Data updated successfully.");
            }
            catch (OracleException ex)
            {
                // Handle Oracle-specific exceptions
                MessageBox.Show($"Oracle error: {ex.Message}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle other general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
