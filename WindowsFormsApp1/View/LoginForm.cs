using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Presenter;

namespace WindowsFormsApp1.View
{
    public partial class LoginForm : Form, IUserView
    {
        SingUpFrom SingUpFrom;

        public List<string> Posts { get; set; }

        public string UserLogin { get; set; }

        public UserPresenter userPresenter { get; set; }


        public LoginForm()
        {
            InitializeComponent();
            //userPresenter = new UserPresenter();
        }


        private void singInButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text != String.Empty && passwordTextBox.Text != String.Empty)
            {
                User u = userPresenter.GetUser(loginTextBox.Text, passwordTextBox.Text);
                AssignAllData(u);
            }
        }

        
        private void singUpButton_Click(object sender, EventArgs e)
        {
            SingUpFrom = new SingUpFrom(userPresenter);
            SingUpFrom.ShowDialog();
        }



        private void AssignAllData(User user)
        {
            Posts = new List<string>();
            Posts = user.Posts;

            UserLogin = user.Login;
        }


    }
}
