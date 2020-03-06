using System;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IUserDao
    {
        void Add(User user);
        void AddMoney(int idUser,float money);
        void RemoveMoney(int idUser,float money);

    }
}
