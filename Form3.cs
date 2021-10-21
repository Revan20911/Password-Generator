using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();

        }
        public string Input
        {
            get { return maskedTextBox1.Text; }
        }

        private void OK_ButtonOnClick(object sender, EventArgs e)
        {
            if (Input != "")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.None;
                Close();
            }
        }




    }
}
