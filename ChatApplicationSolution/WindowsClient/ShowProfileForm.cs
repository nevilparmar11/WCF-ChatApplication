using ChatServiceLibrary.Models;
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

namespace WindowsClient
{
    public partial class ShowProfileForm : Form
    {
        UserServiceClient userService;
        public ShowProfileForm()
        {
            InitializeComponent();
            userService = new UserServiceClient("BasicHttpBinding_IUserService");
            loadControlValues();
        }

        private void loadControlValues()
        {
            this.tbEmail.Text = LoggedInUser.Email;
            this.tbName.Text = LoggedInUser.Name;
            this.tbPassword.Text = LoggedInUser.Password;
            this.tbUsername.Text = LoggedInUser.Username;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string email = tbEmail.Text;
            string name = tbName.Text;
            string password = tbPassword.Text;
            int userid = LoggedInUser.UserId;

            User updatedUser = userService.UpdateUserByUsername(new User(userid, name ,email, password, username));
            tbUsername.Text = updatedUser.Username;
            tbEmail.Text = updatedUser.Email;
            tbName.Text = updatedUser.Name;
            tbPassword.Text = updatedUser.Password;

            LoggedInUser.UserId = updatedUser.UserId;
            LoggedInUser.Name = updatedUser.Name;
            LoggedInUser.Email = updatedUser.Email;
            LoggedInUser.Username = updatedUser.Username;
            LoggedInUser.Password = updatedUser.Password;

            MessageBox.Show("User updated successfully !","Congrats" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string email = tbEmail.Text;
            string name = tbName.Text;
            string password = tbPassword.Text;
            int userid = LoggedInUser.UserId;

            bool success = userService.DeletUserByUsername(new User(userid, name, email, password, username));

            if(success)
            {
                Console.WriteLine("User has been deleted !");
                MessageBox.Show("User has been deleted !", "See you alien", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                LoginForm lgForm = new LoginForm();
                lgForm.Show();
            }
            else
            {
                Console.WriteLine("Failed to delte the user!");
                MessageBox.Show("Failed to delte the user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pswhideview_CheckedChanged(object sender, EventArgs e)
        {
            if (pswhideview.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To Hide";
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                var checkbox = (CheckBox)sender;
                checkbox.Text = "Click To View";
            }
        }
    }
}
