using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

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
                    MessageBox.Show("The first 5 fields cannot be empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (Double.Parse(textBox3.Text) <= 0.0)
                    MessageBox.Show("Price cannot be lower than 0", "Price lower than 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void button_DeleteClick(object sender, EventArgs e)
        {

        }

        private void button_SaveToTxtClick(object sender, EventArgs e)
        {

        }
    }
}
