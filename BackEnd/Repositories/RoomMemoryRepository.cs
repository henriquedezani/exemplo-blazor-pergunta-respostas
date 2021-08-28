using System;
using System.Collections.Generic;
using BackEnd.Entities;
using System.Linq;

namespace BackEnd.Repositories
{
    public class RoomMemoryRepository : IRoomRepository
    {
        private List<Room> rooms = new List<Room>();

        public void Create(Room room)
        {
            rooms.Add(room);
        }

        public void Delete(Guid roomId)
        {
            rooms.Remove(Read(roomId));
        }

        public Room Read(Guid roomId)
        {
            return rooms.SingleOrDefault(room => room.RoomId == roomId);
        }

        public void Update(Room room)
        {
            var _room = Read(room.RoomId);
            _room.Active = room.Active;
        }
    }
}