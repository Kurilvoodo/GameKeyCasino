using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using GameCasino.BLL.Interfaces;
using GameCasino.Ioc;
namespace GameKeyCasino.Models
{
    public class CustomRoleProvider : RoleProvider
    {
        private string _connectionString = @"Data Source=DESKTOP-QALPV5U\SQLEXPRESS;Initial Catalog=GameCasino;Integrated Security=True";
        private IUserLogic _userLogic = DependencyResolver.UserLogic;
        #region void AddUsersToRoles(string[] usernames, string[] roleNames)
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUserToRoleWebsite";

                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IDUser",
                    Direction = ParameterDirection.Input
                };

                var idRoleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IDRole",
                    Direction = ParameterDirection.Input
                };

                connection.Open();
                foreach (string username in usernames)
                {
                    foreach (string role in roleNames)
                    {
                        idUserParameter.Value = _userLogic.GetUserByUsername(username).Id;
                        idRoleParameter.Value = _userLogic.GetIdRoleByRoleName(role);

                        command.Parameters.AddRange(new SqlParameter[] { idUserParameter, idRoleParameter });
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion
        #region string[] GetAllRoles()
        public override string[] GetAllRoles()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRolesWebsite";

                connection.Open();
                var reader = command.ExecuteReader();

                List<string> roles = new List<string>();
                while (reader.Read())
                {
                    roles.Add(reader["Name"] as string);
                }
                return roles.ToArray();
            }
        }
        #endregion
        #region string[] GetRolesForuser(string username)
        public override string[] GetRolesForUser(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRolesForUserWebsite";

                int idUser = _userLogic.GetUserByUsername(username).Id;
                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdUser",
                    Value = idUser,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idUserParameter);

                connection.Open();
                List<string> roles = new List<string>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(reader["Name"] as string);
                }
                return roles.ToArray();
            }
        }
        #endregion
        #region string[] GetUsersInRole(string roleName)
        public override string[] GetUsersInRole(string roleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUsersInRoleWebsite";

                int idRole = _userLogic.GetIdRoleByRoleName(roleName);
                var idRoleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IDRole",
                    Value = idRole,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idRoleParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                List<string> users = new List<string>();
                while (reader.Read())
                {
                    users.Add(reader["Username"] as string);
                }
                return users.ToArray();
            }
        }
        #endregion
        #region bool IsUserInRole(string username, string roleName)
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}