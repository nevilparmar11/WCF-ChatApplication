using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class ChatChoiceForm : Form
    {
        public ChatChoiceForm()
        {
            InitializeComponent();
        }

        private void btnOneChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            OneToOneChatForm otoForm = new OneToOneChatForm(this);
            otoForm.Show();
        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            this.Hide();
            BroadcastChatForm brFrom = new BroadcastChatForm(this);
            brFrom.Show();
        }

        private void ChatChoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Show profile button clicked");
            ShowProfileForm profileForm = new ShowProfileForm(this);
            profileForm.ShowDialog();
        }
    }
}
