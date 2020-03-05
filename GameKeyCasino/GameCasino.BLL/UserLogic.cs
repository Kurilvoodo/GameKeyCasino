using System;
using GameCasino.BLL.Interfaces;
using GameCasino.Dao.Interfaces;
using GameCasino.Entities;
namespace GameCasino.BLL
{
    public class UserLogic : IUserLogic
    {
        private static IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public void Add(User user)
        {
            _userDao.Add(user);
        }

        public void AddMoney(float money)
        {
            _userDao.AddMoney(money);
        }

        public void RemoveMoney(float money)
        {
            _userDao.RemoveMoney(money);
        }
    }
}
