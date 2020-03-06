using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
using System.Data;
using System.Data.SqlClient; 
namespace GameCasino.DAL
{
    public class GameDao : IGameDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public GameCode BuyGameById(Game game, int idUser)
        {
            UserDao userDao = new UserDao();
            userDao.RemoveMoney(idUser,game._ourPrice); //снимаем деньги со счета покупателя.
            GameCodeDao gameCodeDao = new GameCodeDao();
            return gameCodeDao.GetGameCodeByIdGame(game._id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGameById(int idGame)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGameByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
