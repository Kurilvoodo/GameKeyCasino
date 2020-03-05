using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
namespace GameCasino.BLL.Interfaces
{
    public interface IGameLogic
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGameById(int idGame);
        void BuyGameById(int idGame);
        IEnumerable<Game> GetGameByType(string type);
    }
}
