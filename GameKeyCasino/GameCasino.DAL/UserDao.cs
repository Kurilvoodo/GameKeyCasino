using System;
using GameCasino.Entities;
using GameCasino.Dao.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 

namespace GameCasino.DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        public void Add(User user)
        {
            #region Add(User user)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = user._username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = user._password,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);

                var billParameter = new SqlParameter()
                {
                    DbType = DbType.String,  //ПЕРЕПРАВИТЬ ТИПЫ DbType ВЕЗДЕ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    ParameterName = "@Bill",
                    Value = user._bill,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(billParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
            #endregion
        }

        public void AddMoney(int idUser,float money)
        {
            #region AddMoney(int idUser,float money)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddMoney";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var moneyParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Money",
                    Value = money,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(moneyParameter);

                connection.Open();
                command.ExecuteNonQuery();

            }
                #endregion
        }

        public void RemoveMoney(int idUser,float money)
        {
            #region RemoveMoney(int idUser, float money)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveMoney";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Id",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var moneyParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Money",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(moneyParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
            #endregion
        }
    }
}
