using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IGameCode
    {
        GameCode GetGameCodeByIdGame(int idGame);
    }
}
