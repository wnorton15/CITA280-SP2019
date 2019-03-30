using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetflixApp
{
    public partial class FormTestDBConection : Form
    {
        public FormTestDBConection()
        {
            InitializeComponent();
        }

        private void TestDBConectionForm_Load(object sender, EventArgs e)
        {
           
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {

            FormMainMenu.DataBaseConnection(this.txtFileName.Text);
            bool temp = FormMainMenu.TestConnection();
            if (temp)   //Tests if the connection is working
            {
                MessageBox.Show("Connection Working!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

        }

        private void openButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Cursor Files|*.accdb";
            openFileDialog1.Title = "Select a Cursor File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the name and the full path to the txtFileName textBox.  
                this.txtFileName.Text= openFileDialog1.FileName;
            }
        }
    }
}
