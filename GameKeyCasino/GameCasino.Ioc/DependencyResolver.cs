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

        private static IGameLogic _gameLogic;
        public static IGameLogic GameLogic => _gameLogic ?? (_gameLogic = new GameLogic(GameDao));

        private static IGameCodeDao _gameCodeDao;
        public static IGameCodeDao GameCodeDao => _gameCodeDao ?? (_gameCodeDao = new GameCodeDao());

        private static IGameCodeLogic _gameCodeLogic;
        public static IGameCodeLogic GameCodeLogic => _gameCodeLogic ?? (_gameCodeLogic = new GameCodeLogic(GameCodeDao));

        private static IUserDao _userDao;
        public static IUserDao UserDao => _userDao ?? (_userDao = new UserDao());

        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));
    }
}
