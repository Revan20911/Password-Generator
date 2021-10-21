using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;




namespace WindowsFormsApp2
{
  
       
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void GeneratePassword(object sender, EventArgs e)
        {
            var PassType = comboBox1.Text;

            if (PassType == "Normal")
            {
                maskedTextBox1.Text = NormalPass();
            }
            if (PassType == "High Entropy")
            {
                maskedTextBox1.Text = HighSecPass();
            }
            if (PassType == "From String")
            {
                maskedTextBox1.Text = FromString(CharLength(), PassString);
            }
            else
            {
                maskedTextBox1.Text = NormalPass();
            }


        }



        public string PassString = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijklmnopqrstuvwxyz1234567890";

    

        public string NormalPass()
        {
            var path = Path.GetRandomFileName();
            return path;
        }

        public string HighSecPass()
        {
            var path = Path.GetRandomFileName();
            return path.Replace(".", "").Replace("a", "@").Replace("v", "<").Replace("1", "!").Replace("0", ")");
        }

        public int CharLength()
        {
            var str = maskedTextBox3.Text;
            int strlength = 0;

            if (str == "")
            {
                strlength = 255;
                return strlength;
            }
            else
            {
                Int32.TryParse(str, out strlength);
                return strlength;
            }

        }
        //Check the string length field to see if it's empty
        //If empty set strlength to 255 chars

        public string FromString(int strlength, string str)
        {

            string allowedChars = str;
            Random rd = new Random();
            char[] chars = new char[strlength];

            for (int i = 0; i < strlength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);

        }
        public string ConnectionString()
        {
            string connetionString = @"Server=DESKTOP-VDV0FAV\SQLEXPRESS; Database=Passwords; Trusted_Connection=True";
            return connetionString;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //SQL connection string for inserting saved passwords
            //Not sure if necessary with data source connected but ¯\_(ツ)_/¯
            
            SqlConnection pw;

            pw = new SqlConnection(ConnectionString());


            SqlCommand pwa = new SqlCommand("sp_insert", pw);

            pwa.CommandType = CommandType.StoredProcedure;
            pwa.Parameters.AddWithValue("@PassWords", maskedTextBox1.Text);
            pwa.Parameters.AddWithValue("@Website", maskedTextBox2.Text);
            pw.Open();
            int i = pwa.ExecuteNonQuery();

            pw.Close();

            if (i != 0)
            {
                MessageBox.Show("Password Saved");
            }


        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {

            //Calling separate form to enter in custom string to randomize
            if (comboBox1.Text == "From String")
            {
                using (
                Form3 sub = new Form3())
                {
                    switch (sub.ShowDialog())
                    {
                        case DialogResult.OK:
                            PassString = sub.Input;
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.Cancel:
                            break;
                        case DialogResult.Abort:
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            ;
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select 'From String' ");
            }




        }

    }
}


