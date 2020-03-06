using System;
using System.Collections.Generic;
using System.Text;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
using System.Data;
using System.Data.SqlClient; 
namespace GameCasino.DAL
{
    public class GameCodeDao : IGameCodeDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public GameCode GetGameCodeByIdGame(int idGame)
        {
            #region GetGameCodeByIdGame(int idGame)
            GameCode gameCode = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetGameCodeByIdGame";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = idGame,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gameCode = new GameCode(
                        reader["GameCode"] as string,
                        (int)reader["able"]);
                }
            }
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.DeleteGameCodeByIdGame";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = idGame,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
                return gameCode;
            #endregion
        }

        public void unable()
        {
            throw new NotImplementedException();
        }
    }
}
