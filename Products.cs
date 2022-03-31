using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sugar_Factory
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter;
        MainMenu menu = new MainMenu();

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.databaseDataSet.Products);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        public void DisplayData()
        {
            myConnection = new SqlConnection(menu.connection);
            myConnection.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM Products", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void button_InsertClick(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || richTextBox1.Text == "")
                    MessageBox.Show("Fields cannot be empty (except code)", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Double.Parse(textBox3.Text) <= 0.0)
                    MessageBox.Show("Price cannot be lower than 0", "Price lower than 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Int32.Parse(textBox4.Text) <= 0)
                    MessageBox.Show("Quantity cannot be lower than 0", "Quantity lower than 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (dateTimePicker2.Value < dateTimePicker1.Value)
                    MessageBox.Show("Expiration date cannot be lower than the manufacture date", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myConnection = new SqlConnection(menu.connection);
                    myCommand = new SqlCommand("INSERT INTO Products VALUES(@stock, @description, @manufacture_date, @price, @quantity, @expiration_date)", myConnection);

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@stock", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@price", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@quantity", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@description", richTextBox1.Text);
                    myCommand.Parameters.Add("@manufacture_date", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    myCommand.Parameters.Add("@expiration_date", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
                
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully!");

                    myConnection.Close();
                    DisplayData();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    richTextBox1.Clear();
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_UpdateClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(menu.connection);
                myCommand = new SqlCommand("UPDATE Products SET quantity = @quantity WHERE code = @code", myConnection);
                SqlCommand checkCode = new SqlCommand("SELECT code FROM Products WHERE code = @code", myConnection);

                myConnection.Open();
                myCommand.Parameters.AddWithValue("@code", textBox1.Text);
                myCommand.Parameters.AddWithValue("@quantity", textBox4.Text);

                checkCode.Parameters.AddWithValue("@code", textBox1.Text);

                SqlDataReader sdr = checkCode.ExecuteReader();

                if (!sdr.HasRows)
                    MessageBox.Show("No such code in the database", "Code not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    sdr.Close();

                if (textBox1.Text == "")
                    MessageBox.Show("Code cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Int32.Parse(textBox4.Text) <= 0)
                    MessageBox.Show("Quantity cannot be lower than 0", "Quantity lower than 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Quantity updated successfully!");
                    DisplayData();
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_DeleteClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(menu.connection);
                myCommand = new SqlCommand("DELETE Products WHERE code = @code", myConnection);
                SqlCommand checkCode = new SqlCommand("SELECT code FROM Products WHERE code = @code", myConnection);

                myConnection.Open();
                myCommand.Parameters.AddWithValue("@code", textBox1.Text);

                checkCode.Parameters.AddWithValue("@code", textBox1.Text);

                SqlDataReader sdr = checkCode.ExecuteReader();

                if (!sdr.HasRows)
                    MessageBox.Show("No such code in the database", "Code not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    sdr.Close();

                if (textBox1.Text == "")
                    MessageBox.Show("Code cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Product deleted successfully!");
                    DisplayData();
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            string filePath = "D:\\ТУ-Варна\\Семестър 8\\Информационни системи\\Sugar Factory\\Sugar Factory\\queires\\Products.txt";
            DataTableToTextFile(dt, filePath);
            MessageBox.Show("Data saved successfully!", "Data saved!");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
