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
    public partial class PostsForm : Form, IUserView
    {
        public List<string> Posts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserLogin { get; set; }
        public UserPresenter userPresenter { get; set; }

        private int GPCount = 0;
        private int currentUserID;
        private int initialControlNumber;

        public PostsForm(UserPresenter up, int userID)
        {
            InitializeComponent();

            initialControlNumber = this.Controls.Count;


            userPresenter = up;
            userPresenter.UserView = this;

            userPresenter.SelectedUserID = userID;

            this.AutoScroll = true;
            currentUserID = userID;

            UserLogin = userPresenter.UserRepository.GetUserById(userID).Login;

            UpdateForm(UserLogin);
        }


        private void UpdateForm(string userLogin)
        {
            userLoginTextBox.Text = userLogin;
            userLoginTextBox.Enabled = false;

            foreach (string post in userPresenter.UserRepository.GetUserById(userPresenter.SelectedUserID).Posts)
            {
                GroupBox GP = PrepareNewGroupBox();

                (GP.Controls[0] as Button).Text = "Edit";
                (GP.Controls[2] as TextBox).Text = post;
                (GP.Controls[2] as TextBox).Enabled = false;

                this.Controls.Add(GP);
            }

        }


        private GroupBox PrepareNewGroupBox()
        {
            GroupBox GP = new GroupBox();

            GP.Location = new Point(5, 105 + (this.Controls.Count - initialControlNumber) * 200 + 30);  // to modify
            GP.Name = GPCount.ToString();
            GPCount++;
            GP.Size = new Size(450, 150);
            GP.TabStop = false;
            GP.Text = "Post";


            // id = 0
            Button saveButton = new Button();
            saveButton.Name = "saveButton";
            saveButton.Text = "Save";
            saveButton.Size = new Size(55, 25);
            saveButton.Click += new EventHandler(saveButton_Click);
            GP.Controls.Add(saveButton);
            (GP.Controls[0] as Button).Location = new Point(300, 70);


            // id = 1
            Button deleteButton = new Button();
            deleteButton.Name = "deleteButton";
            deleteButton.Text = "Delete";
            deleteButton.Size = new Size(55, 25);
            deleteButton.Click += new EventHandler(deleteButton_Click);
            GP.Controls.Add(deleteButton);
            (GP.Controls[1] as Button).Location = new Point(370, 70);


            // id = 2
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(270, 125);
            GP.Controls.Add(textBox);
            textBox.Location = new Point(5, 15);


            return GP;
        }

        private void ClearAllGroupBoxes()
        {
                for (int i = initialControlNumber; i < this.Controls.Count; i++)
                {
                    this.Controls.RemoveAt(i);
                    i--;
                }
        }

        
        
        // Used when Updating the form (after deleting a post)
        private void UpdateGroupBoxNames()
        {
            for (int i = initialControlNumber; i < this.Controls.Count; i++)
            {
                this.Controls[i].Name = (i - initialControlNumber).ToString();
            }
        }
        
        
        private void addNewPostButton_Click(object sender, EventArgs e)
        {
            GroupBox GP = PrepareNewGroupBox();

            this.Controls.Add(GP);
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            userPresenter.UpdatePost(currentUserID, Int32.Parse((b.Parent as GroupBox).Name), ((b.Parent as GroupBox).Controls[2] as TextBox).Text);
        
            if (b.Text == "Save")
            {
                b.Text = "Edit";
                ((b.Parent as GroupBox).Controls[2] as TextBox).Enabled = false;
            }
            else if (b.Text == "Edit")
            {
                b.Text = "Save";
                ((b.Parent as GroupBox).Controls[2] as TextBox).Enabled = true;
            }
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = sender as Button;
                GroupBox groupBox = b.Parent as GroupBox;

                ClearAllGroupBoxes();

                userPresenter.DeletePost(currentUserID, Int32.Parse(groupBox.Name));  // deleting post in user presenter

                UpdateForm(UserLogin);

                UpdateGroupBoxNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\nStachTrace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void PostsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
