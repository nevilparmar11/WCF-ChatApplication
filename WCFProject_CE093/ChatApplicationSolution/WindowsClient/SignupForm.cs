using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.UserServiceRef;
using ChatServiceLibrary.Models;

namespace WindowsClient
{
    public partial class SignupForm : Form
    {
        UserServiceClient userService;
       
        public SignupForm()
        {
            InitializeComponent();
            userService = new UserServiceClient("BasicHttpBinding_IUserService");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void SignupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string email = tbEmail.Text;

            User newUser = new User(name, email, password, username);

            User user = userService.Register(newUser);

            // Change the Login State
            if (user.Username != null)
            {
                LoggedInUser.UserId = user.UserId;
                LoggedInUser.Name = user.Name;
                LoggedInUser.Email = user.Email;
                LoggedInUser.Username = user.Username;

                Console.WriteLine(LoggedInUser.Username);
                MessageBox.Show("Successfully Registered !" + "\n" + "Please Go back to Login Page");
            }

            else
            {
                MessageBox.Show("User Already Exists!");
            }
        }

        private void pswhideview_CheckedChanged(object sender, EventArgs e)
        {
            if (pswhideview.Checked)
            {
                tbPassword.UseSystemPasswordChar = true;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To View";
            }
            else
            {
                tbPassword.UseSystemPasswordChar = false;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To Hide";
            }
        }
    }
}
