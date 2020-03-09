using System;

namespace GameCasino.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Bill { get; set; }
        public byte[] HashPassword { get; set; }
        public User( string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(int id, string username, decimal bill)
        {
            Id = id;
            Username = username;
            Bill = bill;
        }
        public User()
        { }
    }
}
