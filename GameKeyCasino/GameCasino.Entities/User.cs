using System;

namespace GameCasino.Entities
{
    public class User
    {
        public int _id { get; set; }
        public string _username { get; }
        public string _password { get; }
        public decimal _bill { get; set; }

        public User( string username, string password)
        {
            _username = username;
            _password = password;
            _bill = 0;
        }

        public User(int id, string username, decimal bill)
        {
            _id = id;
            _username = username;
            _bill = bill;
        }
    }
}
