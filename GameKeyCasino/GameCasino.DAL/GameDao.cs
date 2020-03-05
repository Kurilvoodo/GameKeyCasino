using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
//using System.Data.SqlClient; 
namespace GameCasino.DAL
{
    public class GameDao : IGameDao
    {
        void IGameDao.BuyGameById(int idGame)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Game> IGameDao.GetAllGames()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Game> IGameDao.GetGameById(int idGame)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Game> IGameDao.GetGameByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
