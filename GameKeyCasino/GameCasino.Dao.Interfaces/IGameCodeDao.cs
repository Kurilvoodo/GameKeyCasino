using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IGameCodeDao
    {
        GameCode GetGameCodeByIdGame(int idGame);
        void unable();
    }
}
