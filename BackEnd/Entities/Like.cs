using System;

namespace BackEnd.Entities
{
    public class Like
    {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }

        public Like(Guid questionId, Guid userId) 
        {
            QuestionId = questionId;
            UserId = userId;
        }
    }
}