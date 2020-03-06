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

        public void AddMoney(int idUser,float money)
        {
            _userDao.AddMoney(idUser,money);
        }

        public void RemoveMoney(int idUser,float money)
        {
            _userDao.RemoveMoney(idUser,money);
        }
    }
}
