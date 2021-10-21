using System;
using System.Data.SqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'passwordsDataSet.Passwords' table. You can move, or remove it, as needed.
            this.passwordsTableAdapter.Fill(this.passwordsDataSet.Passwords);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            Form1 sub = new Form1();

            var ItemDelete = (Form2)dataGridView1.SelectedRows[0].DataBoundItem;

            using (var pw = new SqlConnection(sub.ConnectionString()))
            {
                pw.Open();

                using (var delete = new SqlCommand("sp_delete", pw))
                {
                    delete.Parameters.AddWithValue("@ID", ItemDelete);
                    delete.ExecuteNonQuery();

                    var datasource = (BindingList<Form2>)dataGridView1.DataSource;
                    datasource.Remove(ItemDelete);
                    
                    i++;
                }
            }

            if (i != 0)
            {
                MessageBox.Show("Record Deleted");
            }

        }



        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
