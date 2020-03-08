using System;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IUserDao
    {
        void Add(User user);
        void AddMoney(int idUser,decimal money);
        void RemoveMoney(int idUser,decimal money);
        bool Authentification(User user);
        decimal GetUserBillByUsername(string username);
    }
}
