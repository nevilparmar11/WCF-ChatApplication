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
        public bool IsChatHistoryLoaded { get; private set; }



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

       
    } // end of class
}
