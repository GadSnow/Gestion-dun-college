using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace School_Management
{
    public partial class LoginForm : Form
    {
        private Authentification auth;
        public LoginForm()
        {
            InitializeComponent();
            auth = new Authentification("Authentification");
        }

        private void login_Click(object sender, EventArgs e)
        {
            string checkResult = auth.checkAuth(username.Text, password.Text); 

            if (checkResult != "")
            {
                DashboardForm dashboardForm = new DashboardForm(checkResult);
                authErrorMessage.Text = "";
                dashboardForm.Show();
                Thread.Sleep(200);
                Hide();

            }
            else
            {
                authErrorMessage.Text = "Nom d'utilisateur ou mot de passe invalide.";
            }

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            login.BackColor = Color.DarkGreen;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
