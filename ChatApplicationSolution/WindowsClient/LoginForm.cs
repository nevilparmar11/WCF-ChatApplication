using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsClient.UserServiceRef;
using ChatServiceLibrary.Models;

namespace WindowsClient
{
    public partial class LoginForm : Form
    {
        UserServiceClient userService;
        public LoginForm()
        {
            InitializeComponent();
            userService = new UserServiceClient("BasicHttpBinding_IUserService");
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupForm signupForm = new SignupForm();
            signupForm.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            User user = userService.Login(username, password);

            // Change the Login State
            if (user.Username != null)
            {
                LoggedInUser.UserId = user.UserId;
                LoggedInUser.Name = user.Name;
                LoggedInUser.Email = user.Email;
                LoggedInUser.Username = user.Username;

                Console.WriteLine(LoggedInUser.Username);
                MessageBox.Show("Successfully LoggedIn !");

                ChatChoiceForm choiceForm = new ChatChoiceForm();
                this.Hide();
                choiceForm.Show();
            }

            else
            {
                MessageBox.Show("Please enter Correct Username and Password");
            }
        }
    }
}
