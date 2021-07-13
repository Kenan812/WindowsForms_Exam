using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Repository
{
    class UserRepository : IUserRepository
    {
        public string xmlPath { get; set; }
        public int PostsCount { get; set; }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
        List<User> usersList;

        public UserRepository(string pathToFolder)
        {
            usersList = new List<User>();

            xmlPath = pathToFolder + "\\users.xml";

            if (File.Exists(xmlPath))
            {
                using (var ser = new StreamReader(xmlPath))
                {
                    usersList = (List<User>)xmlSerializer.Deserialize(ser);
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("users.xml is empty", "No user exist", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        public IEnumerable<User> GetAllUsers()
        {
            return usersList;
        }

        public User GetUserById(int id)
        {
            return usersList[id];
        }



        public void SaveUser(User newUser, int id)
        {
            usersList[id] = newUser;
            SerializeAllUsers(usersList);
        }

        public void AddNewUser(User user)
        {
            usersList.Add(user);
            SerializeAllUsers(usersList);
        }



        private void SerializeAllUsers(List<User> _users)
        {
            using (var ser = new StreamWriter(xmlPath))
            {
                xmlSerializer.Serialize(ser, _users);
            }
        }

        public void UpdateUserPosts(int userID, int postID, string newPost)
        {
            if (userID >= usersList.Count)
            {
                MessageBox.Show("Incorrect user id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                usersList[userID].Posts[postID] = newPost;
            }
            catch (System.Exception)
            {
                // If the post is new

                usersList[userID].AddPost(newPost);
            }

            SerializeAllUsers(usersList);
        }


        public void DeleteUserPost(int userID, int postID)
        {
            if (userID >= usersList.Count || postID >= usersList[userID].Posts.Count)
            {
                MessageBox.Show("Incorrect user or post id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                usersList[userID].Posts.RemoveAt(postID);

            }
            catch (System.Exception)
            {
                MessageBox.Show("Unable to remove post", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SerializeAllUsers(usersList);

        }


        public int GetUserCount()
        {
            return usersList.Count;
        }


    }
}
