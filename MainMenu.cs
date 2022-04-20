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

namespace Sugar_Factory
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ТУ-Варна\Семестър 8\Информационни системи\Sugar Factory\Sugar Factory\Database.mdf;Integrated Security=True";

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Hide();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the app?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void catalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog();
            catalog.Show();
            this.Hide();
        }

        private void salesByClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesByClient sales_by_client = new SalesByClient();
            sales_by_client.Show();
            this.Hide();
        }

        private void salesByStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesByStock sales_by_stock = new SalesByStock();
            sales_by_stock.Show();
            this.Hide();
        }

        private void salesByPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesByPrice sales_by_price = new SalesByPrice();
            sales_by_price.Show();
            this.Hide();
        }

        private void salesByQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesByQuantity sales_by_quantity = new SalesByQuantity();
            sales_by_quantity.Show();
            this.Hide();
        }

        private void clientsByCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsByCity clients_by_city = new ClientsByCity();
            clients_by_city.Show();
            this.Hide();
        }
    }
}
