using System;
using System.Collections.Generic;
using BackEnd.Entities;

namespace BackEnd.Repositories
{
    public interface IQuestionRepository
    {
        void Create(Question question);
        Question Read(Guid questionId);
        List<Question> ReadAll(Guid roomId);
        void Update(Question question);
        void Delete(Guid questionId);
    }
}