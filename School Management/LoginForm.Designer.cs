namespace School_Management
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.authErrorMessage = new System.Windows.Forms.Label();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.login = new Guna.UI2.WinForms.Guna2Button();
            this.username = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.AutoSize = true;
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(94)))));
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1618, 953);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(533, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Harounaya Bilingual International";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.panel1.Controls.Add(this.authErrorMessage);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.login);
            this.panel1.Controls.Add(this.username);
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1618, 543);
            this.panel1.TabIndex = 1;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // authErrorMessage
            // 
            this.authErrorMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.authErrorMessage.AutoSize = true;
            this.authErrorMessage.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.authErrorMessage.Location = new System.Drawing.Point(591, 336);
            this.authErrorMessage.Name = "authErrorMessage";
            this.authErrorMessage.Size = new System.Drawing.Size(0, 23);
            this.authErrorMessage.TabIndex = 4;
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.password.BorderRadius = 3;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.Parent = this.password;
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(94)))));
            this.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.password.FocusedState.Parent = this.password;
            this.password.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.HoverState.Parent = this.password;
            this.password.IconLeft = global::School_Management.Properties.Resources.key;
            this.password.IconLeftOffset = new System.Drawing.Point(4, 0);
            this.password.Location = new System.Drawing.Point(594, 191);
            this.password.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.password.Name = "password";
            this.password.PasswordChar = '\0';
            this.password.PlaceholderText = " Mot de passe";
            this.password.SelectedText = "";
            this.password.ShadowDecoration.Parent = this.password;
            this.password.Size = new System.Drawing.Size(426, 51);
            this.password.TabIndex = 2;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // login
            // 
            this.login.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.login.BorderRadius = 3;
            this.login.CheckedState.Parent = this.login;
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.CustomImages.Parent = this.login;
            this.login.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(194)))), ((int)(((byte)(97)))));
            this.login.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.Color.White;
            this.login.HoverState.Parent = this.login;
            this.login.Image = global::School_Management.Properties.Resources.login_1_;
            this.login.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.login.Location = new System.Drawing.Point(594, 277);
            this.login.Name = "login";
            this.login.ShadowDecoration.Parent = this.login;
            this.login.Size = new System.Drawing.Size(426, 53);
            this.login.TabIndex = 3;
            this.login.Text = "Se connecter";
            this.login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // username
            // 
            this.username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.username.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.username.BorderRadius = 3;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.Parent = this.username;
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(94)))));
            this.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(67)))));
            this.username.FocusedState.Parent = this.username;
            this.username.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.HoverState.Parent = this.username;
            this.username.IconLeft = global::School_Management.Properties.Resources.user_1_;
            this.username.IconLeftOffset = new System.Drawing.Point(4, 0);
            this.username.Location = new System.Drawing.Point(594, 123);
            this.username.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = " Nom d\'utilisateur";
            this.username.SelectedText = "";
            this.username.ShadowDecoration.Parent = this.username;
            this.username.Size = new System.Drawing.Size(426, 56);
            this.username.TabIndex = 1;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2PictureBox1.Image = global::School_Management.Properties.Resources.education;
            this.guna2PictureBox1.Location = new System.Drawing.Point(691, 27);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(232, 159);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1618, 953);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 850);
            this.Name = "LoginForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button login;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label authErrorMessage;
    }
}

