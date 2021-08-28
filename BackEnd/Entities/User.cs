using System;

namespace BackEnd.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}