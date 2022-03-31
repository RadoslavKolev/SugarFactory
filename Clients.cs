using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sugar_Factory
{
    public partial class Clients : Form
    {
        public Clients()
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
            adapter = new SqlDataAdapter("SELECT * FROM Clients", myConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            myConnection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Clients_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSetClients.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.databaseDataSetClients.Clients);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            DisplayData();
        }

        private void button_InsertClick(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("Fields cannot be empty (except id)", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!textBox4.Text.Contains("@"))
                    MessageBox.Show("Email must have \"@\" symbol!", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text.EndsWith("@"))
                    MessageBox.Show("Email must have the mail site after \"@\"!", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text.Length != 10)
                    MessageBox.Show("Phone number must have 10 symbols", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myConnection = new SqlConnection(menu.connection);
                    myCommand = new SqlCommand("INSERT INTO Clients VALUES(@name, @address, @email, @phone, @city)", myConnection);

                    myConnection.Open();
                    myCommand.Parameters.AddWithValue("@name", textBox2.Text);
                    myCommand.Parameters.AddWithValue("@address", textBox3.Text);
                    myCommand.Parameters.AddWithValue("@email", textBox4.Text);
                    myCommand.Parameters.AddWithValue("@phone", textBox5.Text);
                    myCommand.Parameters.AddWithValue("@city", textBox6.Text);


                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Client added successfully!");

                    myConnection.Close();
                    DisplayData();

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Dispose();

                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
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
                myCommand = new SqlCommand("UPDATE Clients SET name = @name, address = @address, email = @email, phone = @phone, city = @city WHERE client_id = @id", myConnection);
                SqlCommand checkCode = new SqlCommand("SELECT client_id FROM Clients WHERE client_id = @id", myConnection);

                myConnection.Open();
                myCommand.Parameters.AddWithValue("@id", textBox1.Text);
                myCommand.Parameters.AddWithValue("@name", textBox2.Text);
                myCommand.Parameters.AddWithValue("@address", textBox3.Text);
                myCommand.Parameters.AddWithValue("@email", textBox4.Text);
                myCommand.Parameters.AddWithValue("@phone", textBox5.Text);
                myCommand.Parameters.AddWithValue("@city", textBox6.Text);

                checkCode.Parameters.AddWithValue("@id", textBox1.Text);

                SqlDataReader sdr = checkCode.ExecuteReader();

                if (!sdr.HasRows)
                    MessageBox.Show("No such client ID in the database", "Client ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    sdr.Close();

                if (textBox1.Text == "")
                    MessageBox.Show("ID cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!textBox4.Text.Contains("@"))
                    MessageBox.Show("Email must have \"@\" symbol!", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox4.Text.EndsWith("@"))
                    MessageBox.Show("Email must have the mail site after \"@\"!", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (textBox5.Text.Length != 10)
                    MessageBox.Show("Phone number must have 10 symbols", "Incorrect Syntax", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Client updated successfully!");
                    DisplayData();
                }

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
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
                myCommand = new SqlCommand("DELETE Clients WHERE client_id = @id", myConnection);
                SqlCommand checkCode = new SqlCommand("SELECT client_id FROM Clients WHERE client_id = @id", myConnection);

                myConnection.Open();
                myCommand.Parameters.AddWithValue("@id", textBox1.Text);

                checkCode.Parameters.AddWithValue("@id", textBox1.Text);

                SqlDataReader sdr = checkCode.ExecuteReader();

                if (!sdr.HasRows)
                    MessageBox.Show("No such client ID in the database", "Code not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    sdr.Close();

                if (textBox1.Text == "")
                    MessageBox.Show("ID cannot be empty!", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Client deleted successfully!");
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

            string filePath = "D:\\ТУ-Варна\\Семестър 8\\Информационни системи\\Sugar Factory\\Sugar Factory\\queires\\Clients.txt";
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
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
