using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public List<string> Posts { get; }


        public User(string login, string password, string name)
        {
            Login = login;
            Password = password;
            Name = name;
            Posts = new List<string>();
        }

        public User()
        {
            Login = String.Empty;
            Password = String.Empty;
            Name = String.Empty;
            Posts = new List<string>();
        }

        public void AddPost(string text)
        {
            Posts.Add(text);
        }
    }
}
