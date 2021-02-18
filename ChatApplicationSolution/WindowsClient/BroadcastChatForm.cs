using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Diagnostics;
using ChatServiceLibrary;
using ChatServiceLibrary.Models;

namespace WindowsClient
{
    
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class BroadcastChatForm : Form, IChatServiceCallback
    {

        #region fields

        // Has the Chat History Been Loaded?
        private bool IsChatHistoryLoaded = false;

        #endregion fields


        #region Constructor

        public BroadcastChatForm()
        {
            InitializeComponent();

            JoinServer(LoggedInUser.Username);
        }

        #endregion Constructor


        #region methods

        private void JoinServer (string username)
        {
            // Check State on Service
            // Make a ChannelFactory Proxy to the Service
            DuplexChannelFactory<IChatService> cf = new DuplexChannelFactory<IChatService>(this, "NetTcpBinding_IChatService");

            cf.Open();
            IChatService proxy = cf.CreateChannel();

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
            DuplexChannelFactory<IChatService> cf = new DuplexChannelFactory<IChatService>(this, "NetTcpBinding_IChatService");
            cf.Open();
            IChatService proxy = cf.CreateChannel();

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
        private void UpdateMessageHistoryUI()
        {
            // If User is Not Logged In
            if (LoggedInUser.Username == null)
            {
                MessageBox.Show("Please Login First !");
                return;
            }

            // Clear the List Box
            lstChatMessages.Items.Clear();

            // Temporary variable to hold the list of chat messages
            List<ChatMessage> historyChat;

            // Retrieve the New Messages
            DuplexChannelFactory<IChatService> cf = new DuplexChannelFactory<IChatService>(this, "NetTcpBinding_IChatService");

            cf.Open();
            IChatService proxy = cf.CreateChannel();

            if (proxy != null)
            {
                try
                {
                    // retrieve the chat history
                    historyChat = proxy.GetMessageHistory();

                    // Update the UI
                    foreach (ChatMessage item in historyChat)
                    {
                        lstChatMessages.Items.Add(item);
                    }

                    IsChatHistoryLoaded = true;

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
                UpdateMessageHistoryUI();
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


        #region IChatServiceCallback Implementation

        public void SendClientMessage(ChatMessage message)
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
                    Action<ChatMessage> del = new Action<ChatMessage>(SendClientMessage);
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
        } // end of method

        #endregion IChatServiceCallback Implementation


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
                using (DuplexChannelFactory<IChatService> cf = new DuplexChannelFactory<IChatService>(this, "NetTcpBinding_IChatService"))
                {
                    cf.Open();
                    IChatService proxy = cf.CreateChannel();

                    if (proxy != null)
                    {
                        try
                        {
                            // It is ok to send empty messages, I don't care lol
                            proxy.SendMessage(LoggedInUser.Username, txtMyMessage.Text);

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


        private void BroadcastChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogOff();
            Application.Exit();
        }

        private void BroadcastChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    } // end of class
}
