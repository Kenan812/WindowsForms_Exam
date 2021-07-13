using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1.Presenter
{
    public class UserPresenter
    {
        public IUserRepository UserRepository { get; set; }
        public IUserView UserView { get; set; }

        public int SelectedUserID { get; set; }

        public UserPresenter(IUserRepository repository, IUserView view)
        {
            this.UserRepository = repository;
            view.userPresenter = this;
            this.UserView = view;
        }


        public User GetUser(string login, string password)
        {
            int count = 0;

            foreach (User u in UserRepository.GetAllUsers())
            {
                if (VerifyLogin(u, login, password))
                {
                    SelectedUserID = count;
                    return u;
                }
                count++;
            }

            MessageBox.Show("Wrong password or login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            return null;
        }


        public void AddUser(User user)
        {
            UserRepository.AddNewUser(user);
        }


        public void UpdatePost(int userID, int postID, string newPost)
        {
            UserRepository.UpdateUserPosts(userID, postID, newPost);
        }

        public void DeletePost(int userID, int postID)
        {
            UserRepository.DeleteUserPost(userID, postID);
        }



        private bool VerifyLogin(User u, string login, string password)
        {
            if (u.Login == login && u.Password == password)
                return true;

            return false;
        }



    }
}
