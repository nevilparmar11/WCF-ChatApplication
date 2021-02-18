using ChatServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;


namespace ChatServiceLibrary
{
  
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        SqlConnection conn;
        SqlCommand cmd;
        UserService userService;

        void DbInit()
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["chatappdbconnectionstring"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

  
        public ChatService()
        {
            DbInit();
            userService = new UserService();
        }

        #region Fields

        private const int maximumMessages = 50;

        private Queue<ChatMessage> chatMessages = new Queue<ChatMessage>();

        private Dictionary<string, IChatServiceCallback> loggedInUsers = new Dictionary<string, IChatServiceCallback>();

        #endregion Fields

        #region IChatService Implementation

        public List<ChatMessage> GetMessageHistory()
        {
            return chatMessages.ToList();
        }


        public bool AddMeToServer(string userName)
        {
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

           
            IChatServiceCallback callback = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();

            if (!loggedInUsers.ContainsKey(userName))
            {
                loggedInUsers.Add(userName, callback);

                SendMessage("Admin", $"User {userName} logged in...");

                Console.WriteLine($"User {userName} logged in...");

                return true;

            } // end of if

            else
            {
                DuplicateUserFault fault = new DuplicateUserFault()
                { Reason = "User '" + userName + "' already logged in!" };
                throw new FaultException<DuplicateUserFault>(fault);
            } // end of else

        } // end of method

     
        public bool LogInState(string userName)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            if (loggedInUsers.ContainsKey(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        } // end of  method

        
        public bool LeaveServer(string userName)
        {
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            try
            {
                if (loggedInUsers.ContainsKey(userName))
                {
                    loggedInUsers.Remove(userName);

                    // Send a Message that the user is Logged Off
                    SendMessage("Admin", $"User {userName} logged off...");

                    // Send Message to Console
                    Console.WriteLine($"User {userName} logged off...");

                    return true; // successfully logged out
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return false;
        } // end of method

       
        public void SendMessage(string userName, string message)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            try
            {
                User user = new User();

                //Verify the User is Logged On First
                if (userName != "Admin" || !loggedInUsers.ContainsKey(userName))
                {
                    user = userService.GetUserByUserName(userName);
                }

                user = userService.GetUserByUserName(userName);

                // Create New Message Object
                ChatMessage chatmessage = new ChatMessage(userName, DateTime.Now, message, user.UserId);

                // Add to Message History
                AddMessage(chatmessage);

                // Transmitt to Connected Users
                SendMessageToUsers(chatmessage);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        } // end of method

        #endregion IChatService Implementation

        #region Methods

        private void AddMessage(ChatMessage message)
        {
            // There is a Message Limit
            // Dequeue then Enqueue
            if (chatMessages?.Count >= maximumMessages)
            {
                chatMessages.Dequeue();
                chatMessages.Enqueue(message);
            }
            // Enqueue
            else
            {
                chatMessages?.Enqueue(message);
            }

            // update message history in database table
            DbInit();
            cmd.CommandText = "Insert into [ChatMessages] values(@UserId,@Name, @Message, @TimeStamp)";
            cmd.Parameters.AddWithValue("@UserId", message.UserId);
            cmd.Parameters.AddWithValue("@Name", message.Name);
            cmd.Parameters.AddWithValue("@Message", message.Message);
            cmd.Parameters.AddWithValue("@TimeStamp", message.TimeStamp);
            conn.Open();
            ChatMessage newMessage;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException e) // If phonenumber is already exists then
            {
                conn.Close();
            }

            newMessage = message;
            conn.Close();

            return;

        } // end of method

      
        private void SendMessageToUsers(ChatMessage message)
        {
            // Inform all of the clients of the new message
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();

            // Loops through each logged in user
            foreach (string key in callbackKeys)
            {
                try
                {
                    IChatServiceCallback callback = loggedInUsers[key];
                    callback.SendClientMessage(message);
                    Console.WriteLine($"Sending user {key} message {message}");
                }
                // catches an issue with a user disconnect and loggs off that user
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    // Remove the disconnected client
                    LeaveServer(key);
                }
            } // end of foreach
        } // end of method

       

        #endregion Methods

    } // end of class
}
