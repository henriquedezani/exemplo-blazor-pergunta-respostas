using System;
using System.Collections.Generic;
using BackEnd.Entities;
using System.Linq;

namespace BackEnd.Repositories
{
    public class LikeMemoryRepository : ILikeRepository
    {
        private List<Like> likes = new List<Like>();

        public void Create(Like like)
        {
            likes.Add(like);
        }

        public void Delete(Guid questionId, Guid userId)
        {
            var like = likes.SingleOrDefault(like => like.QuestionId == questionId && like.UserId == userId);
            likes.Remove(like);
        }
    }
}