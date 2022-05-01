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
using System.IO;

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

            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);

                var delete = dataGridView1.SelectedRows[0].DataBoundItem;

                i++;
                

            }
            
            
            // This code will only run when a database is connected so commenting this out for now
            // This updates the records in the database when the records are deleted from the datagrid view.

//             using (var pw = new SqlConnection(sub.ConnectionString()))
//             {
//                 pw.Open();

//                 using (var delete = new SqlCommand("sp_delete", pw))
//                 {
//                     delete.Parameters.AddWithValue("@ID", ItemDelete);
//                     delete.ExecuteNonQuery();

//                     var datasource = (BindingList<Form2>)dataGridView1.DataSource;
//                     datasource.Remove(ItemDelete);
                    
//                     i++;
//                 }
//             }

            if (i != 0)
            {
                MessageBox.Show("Record Deleted");
                i--;
            }

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    

        private void Export_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CSV (*.csv)|*.csv";
                save.FileName = "Password List.csv";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    int columns = dataGridView1.ColumnCount;
                    string columnName = "";
                    string[] output = new string[dataGridView1.Rows.Count + 1];
                    for (int i = 0; i < columns; i++)
                    {
                        columnName += dataGridView1.Columns[i].HeaderText.ToString();
                    }
                    output[0] += columnName;

                    for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if(dataGridView1.Rows[i - 1].Cells[j].Value  == null)
                            {
                                output[i] += "";
                            }
                            else if(dataGridView1.Rows[i - 1].Cells[j].Value != null)
                            {
                                output[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                            }
                            
                        }
                    }

                    File.WriteAllLines(save.FileName, output, Encoding.UTF8);
                    MessageBox.Show("File saved successfully");

                }

            }
        }

}
