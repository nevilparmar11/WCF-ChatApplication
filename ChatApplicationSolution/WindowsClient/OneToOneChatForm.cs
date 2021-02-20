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
using ChatServiceLibrary;
using ChatServiceLibrary.Models;

namespace WindowsClient
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class OneToOneChatForm : Form, IOneToOneChatCallback
    {
        #region fields

        // Has the Chat History Been Loaded?
        private bool IsChatHistoryLoaded = false;

        #endregion fields

        #region Constructor

        public OneToOneChatForm()
        {
            InitializeComponent();

            JoinServer(LoggedInUser.Username);
        }

        #endregion Constructor

        #region methods

        private void JoinServer(string username)
        {
            // Check State on Service
            // Make a ChannelFactory Proxy to the Service
            DuplexChannelFactory<IOneToOneChatService> cf = new DuplexChannelFactory<IOneToOneChatService>(this, "NetTcpBinding_IOneToOneChatService");

            cf.Open();
            IOneToOneChatService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    proxy.AddMeToServer(username);
                    Console.WriteLine("Inside join server");
                    // Disable the GUI for Chat
                    UpdateChatGUI(true);

                } // end of try

                catch (FaultException<DuplicateUserFault> ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Detail.Reason, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    MessageBox.Show(ex.Detail.Reason);
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    MessageBox.Show("Error logging off user: " + ex.Message);
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
            } // end of else

        }


        /// <summary>
        /// LogOff
        /// Logs off the user from the service
        /// and updates the GUI locally
        /// </summary>
        private void LogOff()
        {
            // Call the Service to Log Off
            DuplexChannelFactory<IOneToOneChatService> cf = new DuplexChannelFactory<IOneToOneChatService>(this, "NetTcpBinding_IOneToOneChatService");
            cf.Open();
            IOneToOneChatService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    proxy.LeaveServer(LoggedInUser.Username);

                    // Disable the GUI for Chat
                    UpdateChatGUI(false);

                } // end of try

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    MessageBox.Show("Error logging off user: " + ex.Message);
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
            } // end of else

        } // end of method

        /// <summary>
        /// GetMessageHistory
        /// Gets a list of ChatMessages to update
        /// the UI list box
        /// </summary>
        private void UpdateMessageHistoryUI(bool multipleTimes)
        {
            // If User is Not Logged In
            if (LoggedInUser.Username == null)
            {
                MessageBox.Show("Please Login First !");
                return;
            }

            // Temporary variable to hold the list of chat messages
            List<SingleChatMessage> historyChat;


            // Retrieve the New Messages
            DuplexChannelFactory<IOneToOneChatService> cf = new DuplexChannelFactory<IOneToOneChatService>(this, "NetTcpBinding_IOneToOneChatService");

            cf.Open();
            IOneToOneChatService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    IsChatHistoryLoaded = true;

                    if(LoggedInUser.receiverName == LoggedInUser.previousReceiver || multipleTimes) 
                    {
                        if(LoggedInUser.receiverName == null)
                        {
                            lstChatMessages.Items.Clear();
                            lstChatMessages.Items.Add("NO MESSAGE RECORDS");
                        }
                    }
                    else
                    {
                        lstChatMessages.Items.Clear();

                        // retrieve the chat history
                        historyChat = proxy.GetMessageHistory(LoggedInUser.Username, LoggedInUser.receiverName);

                        
                        if (historyChat.Count == 0)
                        {
                            lstChatMessages.Items.Add("NO MESSAGE RECORDS");
                            return;
                        }

                        foreach(SingleChatMessage msg in historyChat)
                        {
                            lstChatMessages.Items.Add(msg);
                            Console.WriteLine("MSG : " + msg);
                        }

                        Console.WriteLine("Sender : " + LoggedInUser.Username + " Receiver : " + LoggedInUser.receiverName);
                    }
                  

                } // end of try

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    MessageBox.Show(ex.Message);
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
            } // end of else

        } // end of method


        private void UpdateOnlineUsersListboxUI()
        {
            // If User is Not Logged In
            if (LoggedInUser.Username == null)
            {
                MessageBox.Show("Please Login First !");
                return;
            }

            // Clear the List Box
            lbOnlineUsers.Items.Clear();

            // Temporary variable to hold the list of chat messages
            List<string> receivedOnlineUsers;

            // Retrieve the New Messages
            DuplexChannelFactory<IOneToOneChatService> cf = new DuplexChannelFactory<IOneToOneChatService>(this, "NetTcpBinding_IOneToOneChatService");

            cf.Open();
            IOneToOneChatService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // retrieve the online username from the server
                    receivedOnlineUsers = proxy.GetAllOnlineUsers(LoggedInUser.Username);

                    // Update the UI
                    foreach (string item in receivedOnlineUsers)
                    {
                        lbOnlineUsers.Items.Add(item);
                    }

                } // end of try

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    MessageBox.Show(ex.Message);
                }

            } // end of if

            else
            {
                // Cannot Connect to Server 
                MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
            } // end of else

        } // end of method


        /// <summary>
        /// UpdateChatGUI
        /// Cleans house on the GUI to make it in sync
        /// with being logged in, able to send messages, etc...
        /// </summary>
        /// <param name="enabled">true to enable chat, false otherwise</param>
        private void UpdateChatGUI(bool enabled)
        {
            if (enabled)
            {
                // Update the GUI to Enable Chat
                btnSendMessage.Enabled = true;
                txtMyMessage.Enabled = true;
                UpdateMessageHistoryUI(false);
                UpdateOnlineUsersListboxUI();
                Console.WriteLine("Inside update chat gui ");
            }
            else
            {
                // Update the GUI to Disable Chat
                // Changes back to Login Screen
                btnSendMessage.Enabled = false;
                txtMyMessage.Enabled = false;
            }
        } // end of method



        #endregion methods

        #region Ionetoonechatservicecallback implementataion
        public void SendMessageToParticularClient(SingleChatMessage message)
        {
            // Don't receive any messages until the chat history is loaded
            if (!IsChatHistoryLoaded)
            {
                return;
            }

            try
            {
                // UI Threading Sync
                if (lstChatMessages.InvokeRequired)
                {
                    // UI Thread Sync is Required, Invoke the Request on the
                    // UI thread
                    Action<SingleChatMessage> del = new Action<SingleChatMessage>(SendMessageToParticularClient);
                    lstChatMessages.BeginInvoke(del, message);
                }
                // Add the recent chat message to the listbox
                else
                {
                    lstChatMessages.Items.Add(message);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Error receiving message: " + ex.Message);
            }
        }

        public void SendNewConnectedUserNameToAllOnlineUsers(string connecting_user)
        {
            // add newly connected username name to the list of online users in the Listbox
            try
            {
                // UI Threading Sync
                if (lstChatMessages.InvokeRequired)
                {
                    // UI Thread Sync is Required, Invoke the Request on the
                    // UI thread
                    Action<string> del = new Action<string>(SendNewConnectedUserNameToAllOnlineUsers);
                    lstChatMessages.BeginInvoke(del, connecting_user);
                }
                // Add the recent online users names to the listbox
                else
                {
                    lbOnlineUsers.Items.Add((string)connecting_user);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Error receiving message: " + ex.Message);
            }
        }

        #endregion Ionetoonechatservicecallback implementation


        /// <summary>
        /// btnSendMessage_Click
        /// Implements the Send Message Button Click
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            // Validate User LoggedIn
            if (txtMyMessage.Enabled == false || LoggedInUser.Username == null)
            {
                // User needs to login!
                MessageBox.Show("Please login before sending a message.", "Login Required", MessageBoxButtons.OK);
            }
            else
            {
                // Send Message to Service
                // Retrieve the New Messages
                using (DuplexChannelFactory<IOneToOneChatService> cf = new DuplexChannelFactory<IOneToOneChatService>(this, "NetTcpBinding_IOneToOneChatService"))
                {
                    cf.Open();
                    IOneToOneChatService proxy = cf.CreateChannel();

                    if (proxy != null)
                    {
                        try
                        {
                            // It is ok to send empty messages, I don't care lol
                            proxy.SendMessageToParticularUser(LoggedInUser.Username,LoggedInUser.receiverName, txtMyMessage.Text);

                        } // end of try

                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                            MessageBox.Show(ex.Message);
                        } // end of catch

                    } // end of if

                    else
                    {
                        // Cannot Connect to Server 
                        MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
                    } // end of else

                } // end of using

            } // end of if

        } // end of method

        /// <summary>
        /// lstChatMessages_MeasureItem
        /// Helps Word Wrap the ListBox 
        /// Thanks to a Slack Article
        /// https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstChatMessages_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(lstChatMessages.Items[e.Index].ToString(), lstChatMessages.Font, lstChatMessages.Width).Height;
        }

        /// <summary>
        /// lstChatMessages_DrawItem
        /// Helps Word Wrap the ListBox
        /// Thanks to a Slack Article
        /// https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstChatMessages_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(lstChatMessages.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }


        private void OneToOneChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogOff();
            Application.Exit();
        }

        private void OneToOneChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lbOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Inside selected index changed method of lbOnlineUsers");
            // Get the value of the current selected index , i.e username of the current chat window
            string currUser = lbOnlineUsers.SelectedItem.ToString();
            Console.WriteLine("Selected User : " + currUser);

            // Get the currUser Index
            int currentUserIndex = lbOnlineUsers.SelectedIndex;

            if (currentUserIndex == -1)
            {
                MessageBox.Show("Invalid User index selection");
            }

            else
            {
                LoggedInUser.previousReceiver = LoggedInUser.receiverName;
                LoggedInUser.receiverName = currUser;
                label1.Text = "Messages With " + currUser;
                IsChatHistoryLoaded = false;
                if (LoggedInUser.previousReceiver == currUser)
                    UpdateMessageHistoryUI(true);
                else
                    UpdateMessageHistoryUI(false);
            }

        }
    }
}
