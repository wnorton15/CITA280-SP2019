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
    public partial class FormMainMenu : Form
    {
        public static string _DBFile;
        public static string _DBConnectionInfo;
        public static void DataBaseConnection(string DatabaseFilename)
        {
            // for more information about different connections go to https://www.connectionstrings.com/access/
            _DBFile = DatabaseFilename;
            _DBConnectionInfo = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + DatabaseFilename + "; Persist Security Info=False";

        }
        public static bool TestConnection()
        {
            OleDbConnection db = new OleDbConnection();
            db.ConnectionString = _DBConnectionInfo;
            bool state = false;
            //Try catch statement testing out the connection to see if it fails or connects
            try
            {                         
                db.Open();

                state = (db.State == ConnectionState.Open);

                db.Close();
            }
            catch
            {
                MessageBox.Show(" Can not connect to the database!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            return state;
        }
        public FormMainMenu()
        {
            InitializeComponent();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTestDBConection TestDBConectionForm = new FormTestDBConection();
            TestDBConectionForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // The user wants to exit the application. Close everything down.
            DialogResult d = MessageBox.Show("Are you sure you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
                Application.Exit();
        }

        private void displayAllMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDisplayAllMovies DisplayAllMoviesForm = new FormDisplayAllMovies();
            DisplayAllMoviesForm.Show();
        }
   
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void insertMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
