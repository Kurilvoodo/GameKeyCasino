using System;
using GameCasino.Entities;
namespace GameCasino.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);
        void AddMoney(int idUser,float money);
        void RemoveMoney(int idUser,float money);
    }
}
