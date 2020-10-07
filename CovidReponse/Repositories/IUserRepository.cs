using System;
using CovidReponse.Models;

namespace CovidReponse
{
    public interface IUserRepository
    {
        public User FindUserByEmail(string email);

        public void CreateUser(User u);

        public User FindUserById(int id);

        public User FindUser(User user);

    }


}
