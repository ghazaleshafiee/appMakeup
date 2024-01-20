using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;
using MakeUp.Data.Context;
using MakeUp.Data.Entities;
using MakeUp.Models;

namespace MakeUp
{
    public partial class Products : Form
    {


        private readonly MyAppContext context;
        public Products()
        {
            InitializeComponent();
            context = new MyAppContext();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                StopIfCaptionIsNull(txtCaption.Text);

                StopIfPriceIsNull(txtnumber.Text);

                long.TryParse(txtnumber.Text, out long price);

                StopIfPriceIsInvalid(price);

                StopIfProductIsDuplicated(null, txtCaption.Text);

                context.Products.Add(new Product 
                {
                   Caption = txtCaption.Text,
                   numder = txtnumber.Text,
                   Price = price,
                    num = txtnum.Text,

                });
                context.SaveChanges();
                ClearInputs();
                RefreshGrid();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StopIfProductIsDuplicated(int? id, string caption)
        {
            if (context.Products.Any(x => x.Id != id && x.Caption.Equals(caption)))
            {
                throw new Exception("این کالا در منو موجود می باشد.");
            }
        }

        private void StopIfPriceIsInvalid(long price)
        {
            if (!(price >= 0))
            {
                throw new Exception("فیلد قیمت معتبر نمی باشد.");
            }
        }

        private void StopIfCaptionIsNull(string caption)
        {
            if (string.IsNullOrEmpty(caption))
            {
                throw new Exception("لطفا عنوان کالا را وارد نمایید.");
            }
        }

        private void StopIfPriceIsNull(string price)
        {
            if (string.IsNullOrEmpty(price))
            {
                throw new Exception("لطفا تعداد را وارد نمایید.");
            }
        }
        private void RefreshGrid()
        {
            dgvMenu.DataSource = context.Products.Select(x => new ProductsViewModel
            {
                Id = x.Id,
                Caption = x.Caption,
                number = x.numder,
                num = x.num,   
                Price = x.Price,
            }).ToList();
        }

        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtCaption.Text = string.Empty;
           
            txtnumber.Text = string.Empty;

            
            txtId.Text = "";
            txtCaption.Text = "";
            txtnumber.Text = "";
            txtnum.Text = "";
            

            txtCaption.Focus();
        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedId = dgvMenu[1, dgvMenu.CurrentRow.Index].Value.ToString();

            var id = int.Parse(selectedId);

            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();

            txtId.Text = product.Id.ToString();
            txtCaption.Text = product.Caption;

            txtnum.Text = product.Price.ToString();
        }

       
        private void dgvMenu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
     
        }

        private void Products_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening_2(object sender, CancelEventArgs e)
        {

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedId = dgvMenu[1, dgvMenu.CurrentRow.Index].Value.ToString();

            var id = int.Parse(selectedId);

            var product = context.Products.Where(x => x.Id == id).FirstOrDefault();

            context.Products.Remove(product);
            context.SaveChanges();

            RefreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                StopIfCaptionIsNull(txtCaption.Text);

                StopIfPriceIsNull(txtnumber.Text);

                long.TryParse(txtnumber.Text, out long price);

                StopIfPriceIsInvalid(price);

                int.TryParse(txtId.Text, out int id);

                StopIfProductIsDuplicated(id, txtCaption.Text);

                var product = context.Products.Where(x => x.Id == id).FirstOrDefault();

                product.Caption = txtCaption.Text;
                product.Price = price;
                product.numder = txtnumber.Text;
                product.num = txtnum.Text;

                context.SaveChanges();

                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMenu_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMenu_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvMenu.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                string selectedId = dgvMenu[1, dgvMenu.CurrentRow.Index].Value.ToString();

                int.TryParse(selectedId, out int id);

                var products = context.Products.Where(x => x.Id == id).FirstOrDefault();

                

                txtId.Text = products.Id.ToString();
                txtCaption.Text = products.Caption;
                txtnumber.Text = products.numder.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMenu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          string newValue = e.ToString();
            RefreshGrid();
        }

        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            string newValue = txtCaption.Text;
            RefreshGrid();
        }

        private void Nofproducts_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
