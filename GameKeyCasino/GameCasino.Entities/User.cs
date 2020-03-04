using System;

namespace GameCasino.Entities
{
    public class User
    {
        public int _id { get; }
        public string _username { get; }
        public string _password { get; }
        public float _bill { get; set; }

        public User(int id, string username, string password, float bill)
        {
            _id = id;
            _username = username;
            _password = password;
        }

        public User(int id, string username, float bill)
        {
            _id = id;
            _username = username;
            _bill = bill;
        }
    }
}
