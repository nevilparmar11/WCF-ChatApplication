using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
       
        public UserService()
        {
            dbInit();
        }

        public string DoWork()
        {
            return "Inside dowork of User service";
        }

        SqlConnection conn;
        SqlCommand cmd;

        void dbInit()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["chatappdbconnectionstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            Console.WriteLine("DB Connection Success !");
        }

        private void sendEmail (string to_send_email, string to_send_username)
        {
            Console.WriteLine("Inside send email method");
            string fromEmail = System.Environment.GetEnvironmentVariable("wcfchatappemail");
            string fromEmailPassword = System.Environment.GetEnvironmentVariable("wcfchatapppassword");

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(to_send_email);
                mail.Subject = "Hey " + to_send_username + " - WCFChatApp";
                mail.Body = "Hi " + to_send_username + ",\n" + "Welcome to WCFChatApp." + "\n" + "Thanks for registering with us." + "\n \n" + "Yours trully, \n" + "Nevil";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public User Login(String username, String password)
        {
            dbInit();
            Console.WriteLine(username);
            Console.WriteLine(password);
            cmd.CommandText = "SELECT * FROM [Users] WHERE Username=@Username and Password=@Password";
            SqlParameter param1 = new SqlParameter("@Username", username);
            SqlParameter param2 = new SqlParameter("@Password", password);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            User fetchedUser = new User();
            while (sqlDataReader.Read())
            {
                fetchedUser.UserId = sqlDataReader.GetInt32(0);
                fetchedUser.Name = sqlDataReader.GetString(1);
                fetchedUser.Email = sqlDataReader.GetString(2);
                fetchedUser.Password = sqlDataReader.GetString(3);
                fetchedUser.Username = sqlDataReader.GetString(4);

                Console.WriteLine(sqlDataReader.GetString(2));
            }
            sqlDataReader.Close();
            conn.Close();
            return fetchedUser;
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }

        public User Register(User user)
        {
            dbInit();
            cmd.CommandText = "Insert into [Users] values(@Name,@Email,@Password,@Username)";
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Username", user.Username);

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                sendEmail(user.Email, user.Username); // send greetings
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                conn.Close();
                return new User();
            }
            conn.Close();
            return user;
        }

        public User GetUserByUserName(string username)
        {
            dbInit();
            Console.WriteLine(username);
            cmd.CommandText = "SELECT * FROM [Users] WHERE Username=@Username";
            SqlParameter param1 = new SqlParameter("@Username", username);
            cmd.Parameters.Add(param1);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            User fetchedUser = new User();
            while (sqlDataReader.Read())
            {
                fetchedUser.UserId = sqlDataReader.GetInt32(0);
                fetchedUser.Name = sqlDataReader.GetString(1);
                fetchedUser.Email = sqlDataReader.GetString(2);
                fetchedUser.Password = sqlDataReader.GetString(3);
                fetchedUser.Username = sqlDataReader.GetString(4);
            }
            sqlDataReader.Close();
            conn.Close();
            return fetchedUser;
        }


        public User UpdateUserByUsername(User olduser)
        {
            dbInit();
            cmd.CommandText = "UPDATE [Users] SET Name=@Name, Email=@Email, Password=@Password, Username=@Username WHERE UserId=@UserId";
            cmd.Parameters.AddWithValue("@Email", olduser.Email);
            cmd.Parameters.AddWithValue("@Name", olduser.Name);
            cmd.Parameters.AddWithValue("@Password", olduser.Password);
            cmd.Parameters.AddWithValue("@Username", olduser.Username);
            cmd.Parameters.AddWithValue("@UserId", olduser.UserId);

            conn.Open();
            User newUser;
            try
            {
                cmd.ExecuteNonQuery();
                newUser = olduser;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                conn.Close();
                return new User();
            }
            conn.Close();
            return olduser;
        }

        public bool DeletUserByUsername(User olduser)
        {
            dbInit();
            cmd.CommandText = "DELETE FROM [Users] WHERE UserId=@UserId";
            cmd.Parameters.AddWithValue("@UserId", olduser.UserId);
            conn.Open();

            int rowEffected = cmd.ExecuteNonQuery();
            conn.Close();
            
            if (rowEffected == 0)     // userId is not valid, ( User not exists of provided id)
                return false; 

            return true; // return success
        }
    }
}
