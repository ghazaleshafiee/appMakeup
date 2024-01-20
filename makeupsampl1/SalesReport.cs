using MakeUp.Data.Context;
using MakeUp.Models;
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
    public partial class SalesReport : Form
    {
        private readonly MyAppContext context;
        public SalesReport()
        {
            InitializeComponent();
            context = new MyAppContext();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            dgvSales.DataSource = (from sales in context.Orders
                                   group sales by new
                                   {
                                       sales.CustomerId,
                                       sales.RegisterDateTime,
                                   } into salesGroup
                                   orderby salesGroup.Key.RegisterDateTime descending
                                   select new SalesReportViewModel
                                   {
                                       Customer = salesGroup.FirstOrDefault().Customer.Ferstname,
                                       OrderNumber = salesGroup.FirstOrDefault().OrderNumber,
                                       OrdersCount = salesGroup.Count(),
                                       TotalPrice = salesGroup.Sum(z => z.Price),
                                       SaleDateTime = salesGroup.Key.RegisterDateTime,
                                   })
                                 .ToList();
        }

        private void dgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            dgvSales.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
