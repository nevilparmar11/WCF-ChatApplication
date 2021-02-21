
namespace WindowsClient
{
    partial class ShowProfileForm
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
            this.pswhideview = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMyProfile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pswhideview
            // 
            this.pswhideview.AutoSize = true;
            this.pswhideview.Checked = true;
            this.pswhideview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pswhideview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pswhideview.Location = new System.Drawing.Point(555, 262);
            this.pswhideview.Name = "pswhideview";
            this.pswhideview.Size = new System.Drawing.Size(60, 22);
            this.pswhideview.TabIndex = 24;
            this.pswhideview.Text = "Hide";
            this.pswhideview.UseVisualStyleBackColor = true;
            this.pswhideview.CheckedChanged += new System.EventHandler(this.pswhideview_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDelete.Location = new System.Drawing.Point(416, 343);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 43);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete My Account";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpdate.Location = new System.Drawing.Point(168, 343);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(179, 43);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPassword.Location = new System.Drawing.Point(322, 258);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(215, 30);
            this.tbPassword.TabIndex = 21;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUsername.Location = new System.Drawing.Point(322, 195);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.ReadOnly = true;
            this.tbUsername.Size = new System.Drawing.Size(215, 30);
            this.tbUsername.TabIndex = 20;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbEmail.Location = new System.Drawing.Point(322, 135);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(215, 30);
            this.tbEmail.TabIndex = 19;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbName.Location = new System.Drawing.Point(322, 82);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(215, 30);
            this.tbName.TabIndex = 18;
            this.tbName.Text = typeof(WindowsClient.LoggedInUser).Name;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblPassword.Location = new System.Drawing.Point(163, 262);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(108, 26);
            this.lblPassword.TabIndex = 17;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblUsername.Location = new System.Drawing.Point(163, 199);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(113, 26);
            this.lblUsername.TabIndex = 16;
            this.lblUsername.Text = "Username";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblEmail.Location = new System.Drawing.Point(163, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 26);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblName.Location = new System.Drawing.Point(163, 79);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 26);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Name";
            // 
            // lblMyProfile
            // 
            this.lblMyProfile.AutoSize = true;
            this.lblMyProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblMyProfile.Location = new System.Drawing.Point(298, 20);
            this.lblMyProfile.Name = "lblMyProfile";
            this.lblMyProfile.Size = new System.Drawing.Size(109, 26);
            this.lblMyProfile.TabIndex = 13;
            this.lblMyProfile.Text = "My Profile";
            // 
            // ShowProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pswhideview);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblMyProfile);
            this.Name = "ShowProfileForm";
            this.Text = "ShowProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox pswhideview;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMyProfile;
    }
}