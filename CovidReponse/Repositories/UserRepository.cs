using System;
using System.Data;
using CovidReponse.Models;
using Dapper;

namespace CovidReponse.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _conn;

        public UserRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public User CreateUser(User u)
        {
            var sql = "INSERT into USER (first_name, last_name, email)"
               + "VALUES (@first_name, @last_name, @email)";

            var rowsAffected = _conn.Execute(sql, u);

            if (rowsAffected > 0)
            {
                return FindUserByEmail(u.email);
            }
            else
            {
                throw new Exception("User was not saved");
            }
        }

        public User FindUserByEmail(string email)
        {
            var sql = "SELECT * FROM USER"
                + "WHERE email = @email ";
            return _conn.QuerySingle<User>(sql, new {email = email });
        }


    }
}
