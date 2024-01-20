using MakeUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeUp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           // this.Hide();
            Login login = new Login(this);
            login.ShowDialog();
        }

       

        private void مدریتکاربرانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.ShowDialog();
        }

        private void تعاریفپایهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void انبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

      

        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void مدیریتکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
        }

        private void مدیریتمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.ShowDialog();
        }

        private void صندوقفاکتورToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Orders orders = new Orders();
            orders.ShowDialog();
        }

        private void کزارشگیریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport salesreport = new SalesReport();
            salesreport.ShowDialog();
        }
    }
}
