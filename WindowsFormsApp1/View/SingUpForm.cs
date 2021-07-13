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
    public partial class SingUpForm : Form, IUserView
    {
        public SingUpForm(UserPresenter up)
        {
            InitializeComponent();

            userPresenter = up;
            userPresenter.UserView = this;
        }

        public List<string> Posts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserLogin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public UserPresenter userPresenter { get; set; }

        
        private void singUnButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text != String.Empty && passwordTextBox.Text != String.Empty && nameTextBox.Text != String.Empty)
            {
                User u = new User(loginTextBox.Text, passwordTextBox.Text, nameTextBox.Text);
                userPresenter.AddUser(u);
                this.Close();
            }
            else
            {
                MessageBox.Show("One of the inputs is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
