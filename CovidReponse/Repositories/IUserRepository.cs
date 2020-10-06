using System;
using CovidReponse.Models;

namespace CovidReponse
{
    public interface IUserRepository
    {
        public User FindUserByEmail(string email);

        public User CreateUser(User u);

    }


}
