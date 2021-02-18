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
using ChatServiceLibrary;
using System.Diagnostics;
using ChatServiceLibrary.Models;

namespace Client
{
    /// <summary>
    /// Chat "Tester" Client
    /// Simple GUI for testing the chat service application
    /// that can be expanded for additional features and
    /// capabilities.
    /// </summary>
    /// <remarks>
    /// Note that the CallbackBehavior attribute has been set 
    /// with the UseSynchronizationContext = false value.  
    /// This prevents the callback from being called on the same
    /// thread as the UI thread which would lead to a deadlock.
    /// </remarks>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class frmMain : Form, IChatServiceCallback
    {
        #region fields

        // Helps Keeps Track of the Client State to Service
        private bool LoggedIn;

        // Username (Autenticated with Service)
        private string userName = "";

        // Has the Chat History Been Loaded?
        private bool IsChatHistoryLoaded = false;

        #endregion fields

        #region contructors

        /// <summary>
        /// frmMain()
        /// Constructor for the Main Form
        /// Initializes the GUI
        /// </summary>
        public frmMain()
        {
      
            // Initializes the Main Form
            InitializeComponent();

            // Initialize UI
            // Set the default loggedin state
            LoggedIn = false;

            // Enable the UI features
            btnConnection.Enabled = true;

            // Disable the Chat Features until user logs in
            UpdateChatGUI(false);

        } // end of main method

        #endregion constructors

        #region events

        /// <summary>
        /// btnConnection_Click
        /// Processes the Login/Logoff Button Control
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnConnection_Click(object sender, EventArgs e)
        {
            // If the User is Logged In, Log Them Off
            if (LoggedIn)
            {
                // Log Off
                LogOff();

                // Disable the Chat Features until user logs in
                UpdateChatGUI(false);

                // Reset the Chat History Flag
                IsChatHistoryLoaded = false;

                return;
            } 

            // Proceed to Login User...

            // Validate UserName
            if (!ValidateGUIUserName())
            {
                return;
            }

            // Validate Login
            if (!Login())
            {
                return;
            }

            // Retrieve the Message History & Update UI
            UpdateMessageHistoryUI();

            // Update the GUI for Chat
            UpdateChatGUI(true);

        } // end of method

        /// <summary>
        /// btnSendMessage_Click
        /// Implements the Send Message Button Click
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">not used</param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            // Validate User LoggedIn
            if (txtMyMessage.Enabled == false || !IsUserLoggedIn(userName))
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
                            proxy.SendMessage(userName, txtMyMessage.Text);

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

        #endregion events

        #region IChatServiceCallback Implementation

        /// <summary>
        /// IChatServiceCallback Implementation
        /// SendClientMessage
        /// Called when a message is received from the server
        /// Processes the incoming message from the service
        /// from the chat conversation and adds to the UI
        /// chat message box
        /// </summary>
        /// <param name="message">the message (ChatMessage) object</param>
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

        #region methods

        /// <summary>
        /// IsUserLoggedIn
        /// Connects to the Service to See if the User is LoggedIn
        /// </summary>
        /// <param name="name">the user name (string)</param>
        /// <returns>a boolean, true if the user is logged in</returns>
        private bool IsUserLoggedIn(string name)
        {
            // If Locally Logged In
            if (LoggedIn)
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
                            // Call the Service 
                            if (proxy.LogInState(name))
                            {
                                // The user is logged in
                                LoggedIn = true;

                                // Update the GUI to Enable Chat
                                UpdateChatGUI(true);

                                return true;
                            }
                            else
                            {
                            
                                // The user is not logged in
                                LoggedIn = false;

                                // Update the GUI to Disable Chat
                                UpdateChatGUI(false);

                                return false;
                            }
                        } // end of try

                        catch (Exception)
                        {
                            MessageBox.Show("Cannot verify logged in state on service.", "Service Issue", MessageBoxButtons.OK);
                            return false;
                        } // end of catch

                    } // end of if

                    else
                    {
                        // Cannot Connect to Server 
                        MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
                        return false;
                    } // end of else

            } // end of main if

            // User is Locally Logged Off
            else
            {
                // Update the GUI to Disable Chat
                UpdateChatGUI(false);

                return false;
            }

        } // end of method

        /// <summary>
        /// ValidateGUIUserName
        /// Validates the username text entry to be not empty
        /// and unique and not already logged in on the 
        /// service
        /// </summary>
        /// <returns>true if a valid user name</returns>
        private bool ValidateGUIUserName()
        {
            // User Text Entry is Valid
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                // Validate User Is Not Already Logged In
                if (!IsUserLoggedIn(txtName.Text))
                {
                    userName = txtName.Text;
                    return true;
                }
                else
                {
                    MessageBox.Show("Username already logged in to service. Choose a different name.", "Existing Username", MessageBoxButtons.OK);
                    return false;
                }
            }
            // User Text Entry is Invalid
            else
            {
                MessageBox.Show("Username cannot be empty.", "Invalid Username", MessageBoxButtons.OK);
                return false;
            }
        } // end of method

        /// <summary>
        /// Login
        /// Tries to login this client's username to the service
        /// </summary>
        /// <returns>true if successful, false otherwise</returns>
        private bool Login()
        {
            DuplexChannelFactory<IChatService> cf = new DuplexChannelFactory<IChatService>(this, "NetTcpBinding_IChatService");

                cf.Open();
                IChatService proxy = cf.CreateChannel();

                if (proxy != null)
                {
                    try
                    {
                        proxy.Login(userName);

                        // Change the Login State
                        LoggedIn = true;

                    return true;
                    } // end of try

                    catch (FaultException<DuplicateUserFault> ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Detail.Reason, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        MessageBox.Show(ex.Detail.Reason);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        MessageBox.Show("Error logging in user: " + ex.Message);
                        return false;
                    } 

                } // end of if

                else
                {
                    // Cannot Connect to Server 
                    MessageBox.Show("Cannot Create a Channel to a Proxy. Check Your Configuration Settings.", "Proxy", MessageBoxButtons.OK);
                    return false;
                } // end of else

        } // end of method

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
                        proxy.Logoff(userName);

                        // Update local field
                        LoggedIn = false;

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
            if (!IsUserLoggedIn(userName))
            {
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
                txtName.Enabled = false;
                btnSendMessage.Enabled = true;
                txtMyMessage.Enabled = true;
                btnConnection.Enabled = true;
                btnConnection.BackgroundImage = Properties.Resources.logon;
            }
            else
            {
                // Update the GUI to Disable Chat
                // Changes back to Login Screen
                txtName.Enabled = true;
                btnConnection.Enabled = true;
                btnSendMessage.Enabled = false;
                txtMyMessage.Enabled = false;
                btnConnection.BackgroundImage = Properties.Resources.logoff;
            }
        } // end of method

        /// <summary>
        /// On Form Exit
        /// Logs off a user from the service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogOff();
        }

        #endregion methods

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } // end of class
} // end of namespace
