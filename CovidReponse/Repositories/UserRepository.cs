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

        public void CreateUser(User u)
        {
            var sql = "INSERT into USER (first_name, last_name, email)"
               + "VALUES (@first_name, @last_name, @email)";

            _conn.Execute(sql, new {first_name = u.first_name, last_name = u.last_name, email = u.email });

            //if (rowsAffected > 0)
            //{
            //    return FindUserByEmail(u.email);
            //}
            //else
            //{
            //    throw new Exception("User was not saved");
            //}
        }

        public User FindUserByEmail(string email)
        {
            var sql = "SELECT * FROM USER"
                + "WHERE email = @email ";
            return _conn.QuerySingle<User>(sql, new {email = email });
        }

        public User FindUser(User user)
        {
            var sql = "SELECT * FROM USER"
               + " WHERE email = @email AND first_name = @first_name AND last_name = @last_name ";
            return _conn.QuerySingle<User>(
                sql,
                new { email = user.email, first_name = user.first_name, last_name = user.last_name });

        }

        public User FindUserById(int id)
        {
            var sql = "SELECT * FROM USER"
                + " WHERE user_id = @id ";
            return _conn.QuerySingle<User>(sql, new { id = id });
        }


    }
}
