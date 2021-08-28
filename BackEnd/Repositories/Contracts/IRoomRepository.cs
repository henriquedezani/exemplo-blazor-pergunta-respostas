using System;
using BackEnd.Entities;

namespace BackEnd.Repositories
{
    public interface IRoomRepository
    {
        void Create(Room room);
        Room Read(Guid rootId);
        void Update(Room room);
        void Delete(Guid roomId);
    }
}