using System;
using System.Security.Cryptography;
using System.Text;
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
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] password = Encoding.Default.GetBytes(user.Password);
                user.HashPassword = sha256.ComputeHash(password);
            }
            _userDao.Add(user);
        }

        public void AddMoney(int idUser,decimal money)
        {
            _userDao.AddMoney(idUser,money);
        }

        public void RemoveMoney(int idUser,decimal money)
        {
            _userDao.RemoveMoney(idUser,money);
        }
        public bool Authentification(User user)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] password = Encoding.Default.GetBytes(user.Password);
                user.HashPassword = sha256.ComputeHash(password);
            }
            return _userDao.Authentification(user);
        }
        public User GetUserByUsername(string username)
        {
            return _userDao.GetUserByUsername(username);
        }
        public int GetIdRoleByRoleName(string roleName)
        {
            return _userDao.GetIdRoleByRoleName(roleName);
        }
    }
}
