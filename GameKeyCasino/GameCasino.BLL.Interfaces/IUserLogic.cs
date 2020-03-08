using System;
using GameCasino.Entities;
namespace GameCasino.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);
        void AddMoney(int idUser,decimal money);
        void RemoveMoney(int idUser,decimal money);
        bool Authentification(User user);
        decimal GetUserBillByUsername(string user);
    }
}
