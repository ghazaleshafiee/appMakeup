using MakeUp.Data.Context;
using MakeUp.Data.Entities;
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
    public partial class Customers : Form
    {
        private readonly MyAppContext context;
        public Customers()
        {
            InitializeComponent();
            context = new MyAppContext();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            ClearInputs();
            
        }
        private void RefreshGrid()
        {
            dgvCustomers.DataSource = context.Customers.ToList();
        }

        private void ClearInputs()
        {
            txtId.Text = string.Empty;
            txtFerstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txttell.Text = string.Empty;

            txtFerstName.Focus();
            txtLastName.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                StopIfFullNameIsNull(txtFerstName.Text);

               StopIfSubscriptionCodeIsNull(txttell.Text);

                StopIfCustomerIsDuplicated(null, txttell.Text, txtLastName.Text);

          //      StopIfSubscriptionCodeIsExist(null, txttell.Text);


                var entity = new Customer
                {
                   lastname = txtLastName.Text,
                   Ferstname = txtFerstName.Text,
                   Tell = txttell.Text,
                   Address = txtAddress.Text,
                };
                context.Customers.Add(entity);
                context.SaveChanges();
                ClearInputs();
                RefreshGrid();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void StopIfCustomerIsDuplicated(int? id, string lastname, string tell)
       {
           if (context.Customers.Any(x => x.Id != id && x.lastname.ToLower().Equals(lastname) && x.Tell.ToLower().Equals(tell)))
          {
                throw new Exception("این کاربر در سیستم موجود می باشد.");
           }
        }


       

    //    private void StopIfSubscriptionCodeIsExist(int? id, string tell)
    //    {
    //        if (context.Customers.Any(x => x.Id != id && x.Tell.Equals(tell)))
    //        {
    //            throw new Exception("شماره تلفن تکراری است");
    //        }
    //    }



        private void StopIfSubscriptionCodeIsNull(string tell)
        {
            if (string.IsNullOrEmpty(tell))
            {
                throw new Exception("لطفا شماره تلفن را وارد کنید");
            }
        }

        private void StopIfFullNameIsNull(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new Exception("لطفا نام مشتری را وارد نمایید.");
            }
        }

      
        private void dgvCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedId = dgvCustomers[1, dgvCustomers.CurrentRow.Index].Value.ToString();

            var id = int.Parse(selectedId);

            var customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();

            txtId.Text = customer.Id.ToString();
            txtLastName.Text = customer.lastname.ToString();
            txtFerstName.Text = customer.Ferstname.ToString();
            txttell.Text = customer.Tell.ToString();
            txtAddress.Text = customer.Address;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                StopIfFullNameIsNull(txtFerstName.Text);

               StopIfSubscriptionCodeIsNull(txttell.Text);

                int.TryParse(txtId.Text, out int id);

                StopIfCustomerIsDuplicated(id, txtLastName.Text, txttell.Text);

         //       StopIfSubscriptionCodeIsExist(id, txttell.Text);

                var customers = context.Customers.Where(x => x.Id == id).FirstOrDefault();

                customers.Ferstname = txtFerstName.Text;
                customers.lastname = txtLastName.Text;
                customers.Tell = txttell.Text;
                customers.Address = txtAddress.Text;

                context.SaveChanges();

                RefreshGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedId = dgvCustomers[1, dgvCustomers.CurrentRow.Index].Value.ToString();

            var id = int.Parse(selectedId);

            var customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();

            context.Customers.Remove(customer);
            context.SaveChanges();

            RefreshGrid();
        }

        private void txttell_TextChanged(object sender, EventArgs e)
        {
            
        }
      
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dgvCustomers_CellvalueChanged (object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvCustomers_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
          
        }

        private void dgvCustomers_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvCustomers.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedId = dgvCustomers[1, dgvCustomers.CurrentRow.Index].Value.ToString();

                int.TryParse(selectedId, out int id);

                var customer = context.Customers.Where(x => x.Id == id).FirstOrDefault();



                txtId.Text = customer.Id.ToString();
                txtFerstName.Text = customer.Ferstname.ToString();
                txtLastName.Text = customer.lastname.ToString();
                txtAddress.Text = customer.Address.ToString();
                txttell.Text = customer.Tell.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}

