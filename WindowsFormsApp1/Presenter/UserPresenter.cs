using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1.Presenter
{
    public class UserPresenter
    {
        IUserRepository userRepository;
        IUserView userView;

        public UserPresenter(IUserRepository repository, IUserView view)
        {
            this.userRepository = repository;
            view.userPresenter = this;
            this.userView = view;
        }


        public User GetUser(string login, string password)
        {
            foreach (User u in userRepository.GetAllUsers())
            {
                if (VerifyLogin(u, password))
                {
                    return u;
                }
            }

            System.Windows.Forms.MessageBox.Show("Wrong password or login", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); ;
            return null;
        }


        public void AddUser(User user)
        {
                MessageBox.Show("Test");

            userRepository.AddNewUser(user);
        }



        private bool VerifyLogin(User u, string password)
        {
            if (u.Password == password)
                return true;

            return false;
        }



    }
}
