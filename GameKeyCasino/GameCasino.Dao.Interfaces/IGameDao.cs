using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
namespace GameCasino.Dao.Interfaces
{
    public interface IGameDao
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGameById(int idGame);
        GameCode BuyGameById(Game game, int idUser);
        IEnumerable<Game> GetGameByType(string type);
    }
}
