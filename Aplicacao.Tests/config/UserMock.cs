using System.Collections.Generic;
using Aplicacao.Core.Models;

namespace Aplicacao.Tests.Service
{
    public class UserMock
    {
        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    UserId = 1,
                    Username = "Elayne",
                    Idade = 29
                },
                new User()
                {
                    UserId = 2,
                    Username = "Natália",
                    Idade = 29
                }
            };
        }

        public static User GetUser()
        {
            return new User()
            {
                UserId = 2,
                Username = "Natália",
                Idade = 29
            };
        }
    }
}