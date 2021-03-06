
namespace Sugar_Factory
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByQuantityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsByCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(218, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "Main Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.catalogToolStripMenuItem,
            this.queriesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesByClientToolStripMenuItem,
            this.salesByStockToolStripMenuItem,
            this.salesByPriceToolStripMenuItem,
            this.salesByQuantityToolStripMenuItem,
            this.clientsByCityToolStripMenuItem});
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(97, 25);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // catalogToolStripMenuItem
            // 
            this.catalogToolStripMenuItem.Name = "catalogToolStripMenuItem";
            this.catalogToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.catalogToolStripMenuItem.Text = "Catalog";
            this.catalogToolStripMenuItem.Click += new System.EventHandler(this.catalogToolStripMenuItem_Click);
            // 
            // salesByClientToolStripMenuItem
            // 
            this.salesByClientToolStripMenuItem.Name = "salesByClientToolStripMenuItem";
            this.salesByClientToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.salesByClientToolStripMenuItem.Text = "Sales By Client";
            this.salesByClientToolStripMenuItem.Click += new System.EventHandler(this.salesByClientToolStripMenuItem_Click);
            // 
            // salesByStockToolStripMenuItem
            // 
            this.salesByStockToolStripMenuItem.Name = "salesByStockToolStripMenuItem";
            this.salesByStockToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.salesByStockToolStripMenuItem.Text = "Sales By Stock";
            this.salesByStockToolStripMenuItem.Click += new System.EventHandler(this.salesByStockToolStripMenuItem_Click);
            // 
            // salesByPriceToolStripMenuItem
            // 
            this.salesByPriceToolStripMenuItem.Name = "salesByPriceToolStripMenuItem";
            this.salesByPriceToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.salesByPriceToolStripMenuItem.Text = "Sales By Price";
            this.salesByPriceToolStripMenuItem.Click += new System.EventHandler(this.salesByPriceToolStripMenuItem_Click);
            // 
            // salesByQuantityToolStripMenuItem
            // 
            this.salesByQuantityToolStripMenuItem.Name = "salesByQuantityToolStripMenuItem";
            this.salesByQuantityToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.salesByQuantityToolStripMenuItem.Text = "Sales By Quantity";
            this.salesByQuantityToolStripMenuItem.Click += new System.EventHandler(this.salesByQuantityToolStripMenuItem_Click);
            // 
            // clientsByCityToolStripMenuItem
            // 
            this.clientsByCityToolStripMenuItem.Name = "clientsByCityToolStripMenuItem";
            this.clientsByCityToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.clientsByCityToolStripMenuItem.Text = "Clients By City";
            this.clientsByCityToolStripMenuItem.Click += new System.EventHandler(this.clientsByCityToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(909, 585);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByQuantityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsByCityToolStripMenuItem;
    }
}

