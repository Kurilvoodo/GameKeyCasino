using System;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 

namespace GameCasino.DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void AddMoney(float money)
        {
            throw new NotImplementedException();
        }

        public void RemoveMoney(float money)
        {
            throw new NotImplementedException();
        }
    }
}
