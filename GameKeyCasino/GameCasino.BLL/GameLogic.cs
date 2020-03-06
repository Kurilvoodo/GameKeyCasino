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
        public GameCode BuyGameById(Game game, int idUser)
        {
            return _gameDao.BuyGameById(game, idUser);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _gameDao.GetAllGames();
        }

        public Game GetGameById(int idGame)
        {
            return _gameDao.GetGameById(idGame);
        }

        public IEnumerable<Game> GetGameByType(string type)
        {
            return _gameDao.GetGameByType(type);
        }
    }
}
