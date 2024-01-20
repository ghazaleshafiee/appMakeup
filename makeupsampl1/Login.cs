using MakeUp;
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
    public partial class Login : Form
    {
        private readonly MyAppContext context;
        private readonly Main _main;

        public Login(Main main)
        {
            InitializeComponent();
            context = new MyAppContext();
            _main = main;
        }

        private void EnterToApp(string username, string password)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                StopIfUsernameIsNullOrEmpty(username);

                StopIfPasswordIsNullOrEmpty(password);

                var user = FindUser(username, password);

                StopIfUserNotFound(user);

                

                this.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void StopIfUsernameIsNullOrEmpty(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new Exception("نام کاربری را وارد کنید");
        }

        private void StopIfPasswordIsNullOrEmpty(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception("رمز عبور را وارد کنید");
        }

        private void StopIfUserNotFound(User user)
        {
            if (user == null)
                throw new Exception("کاربر یافت نشد!");
        }

        private User FindUser(string username, string password)
        {
            return context.Users
                .Where(x => x.Username.ToLower().Equals(username.ToLower()))
                .Where(x => x.Password.ToLower().Equals(password.ToLower()))
                .FirstOrDefault();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            EnterToApp(txtUsername.Text, txtPassword.Text);
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(string username, string password)
        {
           
        }

      


       
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
