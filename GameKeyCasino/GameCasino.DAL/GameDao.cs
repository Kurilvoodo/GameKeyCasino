using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
using System.Data;
using System.Data.SqlClient; 
namespace GameCasino.DAL
{
    public class GameDao : IGameDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public GameCode BuyGameById(Game game, int idUser)
        {
            UserDao userDao = new UserDao();
            userDao.RemoveMoney(idUser,game.OurPrice); //снимаем деньги со счета покупателя.
            GameCodeDao gameCodeDao = new GameCodeDao();
            return gameCodeDao.GetGameCodeByIdGame(game.Id);
        }

        public IEnumerable<Game> GetAllGames()
        {
            #region GetAllGames()
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllGames";

                connection.Open();
                var reader = command.ExecuteReader();
                List<Game> games = new List<Game>();
                while (reader.Read())
                {
                    games.Add(new Game(reader["GameName"] as string,
                        (int)reader["typeOfGame"],
                        (decimal)reader["OurPrice"], 
                        (decimal)reader["BasePrice"])
                    { 
                        Id=(int)reader["Id"]
                    }
                    );
                }
                return games;
            }
            #endregion
        }

        public Game GetGameById(int idGame)
        {
            #region GetGameById(int idGame)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetGameById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = idGame,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                Game game = null;
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    game= new Game(reader["GameName"] as string,
                        (int)reader["typeOfGame"],
                        (decimal)reader["OurPrice"],
                        (decimal)reader["BasePrice"])
                    {
                       Id = (int)reader["Id"]
                    };
                }
                return game;
            }
            #endregion
        }

        public IEnumerable<Game> GetGameByType(int type)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetGameById";

                var typeParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@typeOfGame",
                    Value = type,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(typeParameter);

                connection.Open();
                List<Game> games = new List<Game>();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    games.Add(new Game(reader["GameName"] as string,
                        (int)reader["typeOfGame"],
                        (decimal)reader["OurPrice"],
                        (decimal)reader["BasePrice"])
                    {
                        Id = (int)reader["Id"]
                    });
                }
                return games;
            }
        }
    }
}
