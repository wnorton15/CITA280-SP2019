using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace NetflixApp
{
    public partial class FormDisplayAllMovies : Form
    {
        public FormDisplayAllMovies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mySql = "SELECT* FROM Movies ORDER BY MovieName ASC";
                ///Sets up the connection to the server 
                OleDbConnection cn = new OleDbConnection();
                cn.ConnectionString = FormMainMenu._DBConnectionInfo;
                //open database
                cn.Open();
                //Create an OleDbCommand object.
                //Notice that this line passes in the SQL statement and the OleDbConnection object
             //   OleDbCommand cmd = new OleDbCommand(mySql, cn);

                // Send the CommandText to the connection, and then build an OleDbDataAdapter.

                OleDbDataAdapter adapter = new OleDbDataAdapter(mySql, cn);
                DataSet ds = new DataSet();
                //Fills the table
                adapter.Fill(ds);


                DataTable dt = ds.Tables["TABLE"];      //Creates a datatable of all the movies in the database

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dataGridView1.DataSource = bindingSource;
                adapter.Update(ds);

                //close the database
                cn.Close();
            }
            catch
            {
                MessageBox.Show("You need to go help and test the connection to the database!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
           
            
            //Firstly, null the data source
            dataGridView1.DataSource = null;
            //Then clear the rows:
            dataGridView1.Rows.Clear();


        }
    }
}
