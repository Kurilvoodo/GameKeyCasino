using System;
using GameCasino.BLL;
using GameCasino.BLL.Interfaces;
using GameCasino.DAL;
using GameCasino.Dao.Interfaces;
using System.Linq;
namespace GameCasino.Ioc
{
    public class DependencyResolver
    {
        private static IGameDao _gameDao;
        public static IGameDao GameDao => _gameDao ?? (_gameDao = new GameDao());

        private static IGameCodeDao _gameCodeDao;
        public static IGameCodeDao GameCodeDao => _gameCodeDao ?? (_gameCodeDao = new GameCodeDao());

        private static IUserDao _userDao;
        public static IUserDao UserDao => _userDao ?? (_userDao = new UserDao());
    }
}
