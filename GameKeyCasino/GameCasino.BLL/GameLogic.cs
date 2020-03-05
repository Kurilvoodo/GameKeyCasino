using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.BLL.Interfaces;
using GameCasino.Dao.Interfaces;
using GameCasino.Entities;

namespace GameCasino.BLL
{
    public class GameLogic : IGameLogic
    {
        private static IGameDao _gameDao;
        public GameLogic(IGameDao gameDao) 
        {
            _gameDao = gameDao;
        }
        public void BuyGameById(int idGame)
        {
            _gameDao.BuyGameById(idGame);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _gameDao.GetAllGames();
        }

        public IEnumerable<Game> GetGameById(int idGame)
        {
            return _gameDao.GetGameById(idGame);
        }

        IEnumerable<Game> IGameLogic.GetGameByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
