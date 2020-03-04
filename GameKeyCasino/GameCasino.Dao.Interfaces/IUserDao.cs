using System;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IUserDao
    {
        //void Add(User user);
        void AddMoney(float money);
        void RemoveMoney(float money);

    }
}
