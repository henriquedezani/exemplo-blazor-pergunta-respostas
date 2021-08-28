using System;
using BackEnd.Entities;

namespace BackEnd.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        User Read(Guid userId);
        User Read(string email, string password);
        void Update(User user);
        void Delete(Guid userId);
    }
}