using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
//using System.Data.SqlClient; 
namespace GameCasino.DAL
{
    public class GameCodeDao : IGameCodeDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public GameCode GetGameCodeByIdGame(int idGame)
        {
            throw new NotImplementedException();
        }

        public void unable()
        {
            throw new NotImplementedException();
        }
    }
}
