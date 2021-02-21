
namespace WindowsClient
{
    partial class ChatChoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOneChat = new System.Windows.Forms.Button();
            this.btnBroadcast = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOneChat
            // 
            this.btnOneChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnOneChat.Location = new System.Drawing.Point(79, 124);
            this.btnOneChat.Name = "btnOneChat";
            this.btnOneChat.Size = new System.Drawing.Size(258, 251);
            this.btnOneChat.TabIndex = 0;
            this.btnOneChat.Text = "One-One Chat";
            this.btnOneChat.UseVisualStyleBackColor = true;
            this.btnOneChat.Click += new System.EventHandler(this.btnOneChat_Click);
            // 
            // btnBroadcast
            // 
            this.btnBroadcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnBroadcast.Location = new System.Drawing.Point(428, 124);
            this.btnBroadcast.Name = "btnBroadcast";
            this.btnBroadcast.Size = new System.Drawing.Size(258, 251);
            this.btnBroadcast.TabIndex = 1;
            this.btnBroadcast.Text = "Broadcast Message";
            this.btnBroadcast.UseVisualStyleBackColor = true;
            this.btnBroadcast.Click += new System.EventHandler(this.btnBroadcast_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(281, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome ";
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(323, 392);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(118, 46);
            this.btnProfile.TabIndex = 3;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // ChatChoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBroadcast);
            this.Controls.Add(this.btnOneChat);
            this.Name = "ChatChoiceForm";
            this.Text = "ChatChoiceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOneChat;
        private System.Windows.Forms.Button btnBroadcast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfile;
    }
}