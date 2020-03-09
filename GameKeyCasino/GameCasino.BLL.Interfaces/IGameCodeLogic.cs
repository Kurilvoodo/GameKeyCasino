using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
namespace GameCasino.BLL.Interfaces
{
    public interface IGameCodeLogic
    {
        GameCode GetGameCodeByIdGame(int idGame);
        void Unable();
    }
}
