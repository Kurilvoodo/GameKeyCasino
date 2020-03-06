using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.BLL.Interfaces;
using GameCasino.Dao.Interfaces;
using GameCasino.Entities;

namespace GameCasino.BLL
{
    public class GameCodeLogic : IGameCodeLogic
    {
        private static IGameCodeDao _gameCodeDao;
        public GameCodeLogic(IGameCodeDao gameCodeDao)
        {
            _gameCodeDao = gameCodeDao;
        }

        public GameCode GetGameCodeByIdGame(int idGame)
        {
            return _gameCodeDao.GetGameCodeByIdGame(idGame);
        }

        public void unable()
        {
            _gameCodeDao.unable();
        }
    }
}
