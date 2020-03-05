using System;
using GameCasino.Entities;
namespace GameCasino.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);
        void AddMoney(float money);
        void RemoveMoney(float money);
    }
}
