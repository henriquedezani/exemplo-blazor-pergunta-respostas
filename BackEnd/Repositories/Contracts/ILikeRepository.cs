using System;
using BackEnd.Entities;

namespace BackEnd.Repositories
{
    public interface ILikeRepository
    {
        void Create(Like like);
        void Delete(Guid questionId, Guid userId);
    }
}