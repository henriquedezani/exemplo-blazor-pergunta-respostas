using System;
using System.Collections.Generic;
using BackEnd.Entities;
using System.Linq;

namespace BackEnd.Repositories
{
    public class QuestionMemoryRepository : IQuestionRepository
    {
        private List<Question> questions = new List<Question>();

        public void Create(Question question)
        {
            questions.Add(question);
        }

        public void Delete(Guid questionId)
        {
            questions.Remove(Read(questionId));
        }

        public Question Read(Guid questionId)
        {
            return questions.SingleOrDefault(question => question.QuestionId == questionId);
        }

        public List<Question> ReadAll(Guid roomId)
        {
             return questions.Where(question => question.RoomId == roomId).ToList();
        }

        public void Update(Question question)
        {
            var _question = Read(question.QuestionId);

            _question.Likes = question.Likes;
            _question.Live = question.Live;
            _question.Read = question.Read;
        }
    }
}