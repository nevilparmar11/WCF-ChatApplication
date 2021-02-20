using ChatServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ChatServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class OneToOneChatService : IOneToOneChatService
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


        public OneToOneChatService()
        {
            DbInit();
            userService = new UserService();
        }

        #region Fields
        private const int maximumMessages = 50;

        private Queue<SingleChatMessage> chatMessages = new Queue<SingleChatMessage>();

        private Dictionary<string, IOneToOneChatCallback> loggedInUsers = new Dictionary<string, IOneToOneChatCallback>();
        #endregion Fields


        #region IOneToOneChatService Implementation

        public bool AddMeToServer(string userName)
        {
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }


            IOneToOneChatCallback callback = OperationContext.Current.GetCallbackChannel<IOneToOneChatCallback>();

            if (!loggedInUsers.ContainsKey(userName))
            {
                loggedInUsers.Add(userName, callback);

                Console.WriteLine($"User {userName} logged in...");

                // Notify all the online users about newly joined user
                NotifyAllOnlineUsersAboutNewlyJoinedUser(userName);

                return true;

            } // end of if

            else
            {
                DuplicateUserFault fault = new DuplicateUserFault()
                { Reason = "User '" + userName + "' already logged in!" };
                throw new FaultException<DuplicateUserFault>(fault);
            } // end of else
        }

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
        }

        /// <summary>
        /// Get Chat Message History with sender, receiver pair
        /// </summary>
        /// <param name="sendername"></param>
        /// <param name="receivename"></param>
        /// <returns></returns>
        public List<SingleChatMessage> GetMessageHistory(string sendername, string receivename)
        {
            DbInit();
            Console.WriteLine("Inside Get message history of db");
            Console.WriteLine(sendername + " " + receivename);
            Console.WriteLine("Sender Name : " + sendername);
            Console.WriteLine("Receiver Name : " + receivename);


            cmd.CommandText = "SELECT * FROM [OneToOneChatMessages] WHERE (SenderName = @SenderName AND ReceiveName = @ReceiveName) ORDER BY TimeStamp";
            cmd.Parameters.AddWithValue("@SenderName", sendername);
            cmd.Parameters.AddWithValue("@ReceiveName", receivename);
            conn.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            chatMessages.Clear();

            while (sqlDataReader.Read())
            {
                chatMessages.Enqueue(new SingleChatMessage(sqlDataReader.GetInt32(0),
                                                    sqlDataReader.GetInt32(1),
                                                    sqlDataReader.GetInt32(2),
                                                    sqlDataReader.GetString(3),
                                                    sqlDataReader.GetString(4),
                                                    sqlDataReader.GetString(5),
                                                    sqlDataReader.GetDateTime(6)
                                                    ));

                Console.WriteLine(sqlDataReader.GetString(5));
            }

            sqlDataReader.Close();
            conn.Close();

            Console.WriteLine("Outside get message history of db");

            return chatMessages.ToList();
        }

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

        public void SendMessageToParticularUser(string sender, string receiver, string messageText)
        {
            // Trim the Username to 15 Characters
            if (sender.Length > 15)
            {
                sender = sender.Substring(0, 15);
            }

            try
            {
                User messageSenderUser = new User();
                User messageReceiverUser = new User();

                //Verify the User is Logged On First
                if (sender != "Admin" || receiver != "Admin" || !loggedInUsers.ContainsKey(sender))
                {
                    messageSenderUser = userService.GetUserByUserName(sender);
                }

                messageSenderUser = userService.GetUserByUserName(sender);
                messageReceiverUser = userService.GetUserByUserName(receiver);

                // Create New Message Object
                SingleChatMessage chatmessage = new SingleChatMessage(messageSenderUser.UserId , messageReceiverUser.UserId, sender, receiver, messageText, DateTime.Now);

                // Add to Message History
                AddMessage(chatmessage);    

                // Transmitt to Intended User
                SendMessageToParticularClient(chatmessage, sender ,receiver);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<string> GetAllOnlineUsers(string request_sender)
        {
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();
            List<string> connectedUsers = new List<string>();

            foreach (string key in callbackKeys)
                if(key != request_sender)
                    connectedUsers.Add(key);

            return connectedUsers;
        }

        #endregion IOneToOneChatService Implementation

        #region Methods

        /// <summary>
        /// Methods Adds Message to local queue as well as to DB
        /// </summary>
        /// <param name="message"></param>
        private void AddMessage(SingleChatMessage message)
        {
            DbInit();

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
            cmd.CommandText = "Insert into [OneToOneChatMessages] values(@SenderId, @ReceiveId, @SenderName,@ReceiveName, @Message, @TimeStamp)";
            cmd.Parameters.AddWithValue("@SenderId", message.SenderId);
            cmd.Parameters.AddWithValue("@ReceiveId", message.ReceiveId);
            cmd.Parameters.AddWithValue("@SenderName", message.SenderName);
            cmd.Parameters.AddWithValue("@ReceiveName", message.ReceiverName);
            cmd.Parameters.AddWithValue("@Message", message.Message);
            cmd.Parameters.AddWithValue("@TimeStamp", message.TimeStamp);
            conn.Open();

            SingleChatMessage newMessage;

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

        private void SendMessageToParticularClient(SingleChatMessage chatmessage, string sender ,string intendedReceiver)
        {
            // Inform all of the clients of the new message
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();

            // Loops through each logged in user
            foreach (string key in callbackKeys)
            {
                if(key == intendedReceiver || key == sender)
                {
                    try
                    {
                        IOneToOneChatCallback callback = loggedInUsers[key];
                        callback.SendMessageToParticularClient(chatmessage);
                        Console.WriteLine($"Sending user {key} message {chatmessage}");
                    }
                    // catches an issue with a user disconnect and loggs off that user
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        // Remove the disconnected client
                        LeaveServer(key);
                    }

                } 
            } // end of foreach
        }

        private void NotifyAllOnlineUsersAboutNewlyJoinedUser(string connecting_user)
        {
            // Inform all of the clients of the new message
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();

            // Loops through each logged in user
            foreach (string key in callbackKeys)
            {
                if (key != connecting_user)
                {
                    try
                    {
                        IOneToOneChatCallback callback = loggedInUsers[key];
                        callback.SendNewConnectedUserNameToAllOnlineUsers(connecting_user);
                        Console.WriteLine($"Notifying user {key} about joining of {connecting_user}");
                    }
                    // catches an issue with a user disconnect and loggs off that user
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        // Remove the disconnected client
                        LeaveServer(key);
                    }

                }
            } // end of foreach
        }


        #endregion Methods
    }
}
