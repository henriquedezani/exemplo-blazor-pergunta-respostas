using System;

namespace BackEnd.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public bool Active { get; set; } = true;

        #region Foreign Key
        public User User { get; set; }
        #endregion
    }
}