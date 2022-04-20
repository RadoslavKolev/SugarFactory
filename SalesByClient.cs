﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sugar_Factory
{
    public partial class SalesByClient : Form
    {
        public SalesByClient()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);
        public SqlDataAdapter adapter;
        MainMenu menu = new MainMenu();

        private void SalesByClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSetClients.Clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.databaseDataSetClients.Clients);

        }

        private void button_ShowClick(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(menu.connection);
                myCommand = new SqlCommand("SELECT s.sale_code AS 'Sale Code', p.stock AS 'Stock Name', c.name AS 'Client', s.sale_date AS 'Sale Date', s.quantity AS 'Quantity', s.price_VAT AS 'Price' " +
                    "FROM Sales s, Products p, Clients c " +
                    "WHERE c.name = @name AND s.client_id = c.client_id AND s.stock_code = p.code", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@name", textBox1.Text);
                myCommand.ExecuteNonQuery();

                SqlDataReader rdr = myCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(rdr);
                dataGridView1.DataSource = dataTable;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

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

            string filePath = "D:\\ТУ-Варна\\Семестър 8\\Информационни системи\\Sugar Factory\\Sugar Factory\\queires\\Sales By Client.txt";
            DataTableToTextFile(dt, filePath);
            MessageBox.Show("Data saved successfully!", "Data saved!");
        }

        private void button_BackToMainClick(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
