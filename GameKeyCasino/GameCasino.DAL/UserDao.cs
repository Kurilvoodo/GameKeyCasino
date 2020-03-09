﻿using System;
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
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Password",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);

                var billParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,  //ПЕРЕПРАВИТЬ ТИПЫ DbType ВЕЗДЕ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    ParameterName = "@Bill",
                    Value = user.Bill,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(billParameter);

                connection.Open();
                command.ExecuteNonQuery();
            }
            #endregion
        }

        public void AddMoney(int idUser, decimal money)
        {
            #region AddMoney(int idUser,float money)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddMoney";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var moneyParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
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

        public void RemoveMoney(int idUser, decimal money)
        {
            #region RemoveMoney(int idUser, float money)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveMoney";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var moneyParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
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
        public bool Authentification(User user)
        {
            #region bool Authentification(User user)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Authentification";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Password",
                    Value = user.HashPassword,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(passwordParameter);

                connection.Open();

                var resultCommand = command.ExecuteScalar();

                return (int)resultCommand > 0;

            }
            #endregion
        }
        public User GetUserByUsername(string username)
        {
            #region GetUserBillByUsername (string username)
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserByUsername";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = username,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(usernameParameter);
                connection.Open();
                User userinfo = null;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    string _username = reader["Username"] as string;
                    decimal bill = (decimal)reader["Bill"];
                    userinfo = new User()
                    {
                        Id = id,
                        Username = _username,
                        Bill = bill
                    };
                }
                return userinfo;
            }
            #endregion
        }
        public int GetIdRoleByRoleName(string roleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetIdRoleByRoleName";

                var roleNameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@RoleName",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(roleNameParameter);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
    }
}
