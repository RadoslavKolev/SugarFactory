using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sugar_Factory
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter;
        MainMenu menu = new MainMenu();

        public void DisplayData()
        {
            myConnection = new SqlConnection(menu.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Sales", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSetClients.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.databaseDataSetClients.Clients);
            // TODO: This line of code loads data into the 'databaseDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.databaseDataSet.Products);
            // TODO: This line of code loads data into the 'databaseDataSet1.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.databaseDataSet1.Sales);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        private void button_InsertClick(object sender, EventArgs e)
        {
            
        }

        private void button_UpdateClick(object sender, EventArgs e)
        {

        }

        private void button_DeleteClick(object sender, EventArgs e)
        {

        }

        private void DataTableToTextFile(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                            maxLengths[i] = length;
                    }
                }
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFilePath, false))
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                        sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));

                    sw.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (!row.IsNull(i))
                                sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                            else
                                sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                }
            }
            catch { }
        }

        private void button_SaveToTxtClick(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = menu.connection;

            DataTable dt = new DataTable();
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                dt.Columns.Add(column.Name, column.ValueType);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                    if (row.Cells[column.Name].Value != null)
                        dr[column.Name] = row.Cells[column.Name].Value.ToString();
                dt.Rows.Add(dr);
            }

            string filePath = "D:\\ТУ-Варна\\Семестър 8\\Информационни системи\\Sugar Factory\\Sugar Factory\\queires\\Sales.txt";
            DataTableToTextFile(dt, filePath);
            MessageBox.Show("Data saved successfully!", "Data saved!");
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();          
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox3.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
