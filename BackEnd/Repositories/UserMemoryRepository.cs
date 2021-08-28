using System;
using System.Collections.Generic;
using BackEnd.Entities;
using System.Linq;

namespace BackEnd.Repositories
{
    public class UserMemoryRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public void Create(User user)
        {
            users.Add(user);
        }

        public void Delete(Guid userId)
        {
            users.Remove(Read(userId));
        }

        public User Read(Guid userId)
        {
            return users.SingleOrDefault(user => user.UserId == userId);
        }

        public User Read(string email, string password)
        {
            return users.SingleOrDefault(user => user.Email == email && user.Password == password);
        }

        public void Update(User user)
        {
            var _user = Read(user.UserId);
            _user.Nome = user.Nome;
            _user.Password = user.Password;
        }
    }
}