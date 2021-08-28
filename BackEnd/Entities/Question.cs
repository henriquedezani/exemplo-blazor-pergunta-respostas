using System;

namespace BackEnd.Entities
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public bool Read { get; set; }
        public bool Live { get; set; }
        public int Likes { get; set; }

        #region Foreign Key
        public User User { get; set; }
        #endregion

        public Question(Guid roomId, Guid userId, string text)
        {
            QuestionId = Guid.NewGuid();
            RoomId = roomId;
            UserId = userId;
            Text = text;
            Read = false;
            Live = false;
            Likes = 0;
        }
    }
}