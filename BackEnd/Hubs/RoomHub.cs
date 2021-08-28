using System;
using System.Threading.Tasks;
using BackEnd.Entities;
using BackEnd.Repositories;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    public class RoomHub : Hub
    {        
        private IQuestionRepository questionRepository;
        private ILikeRepository likeRepository;

        public RoomHub(IQuestionRepository questionRepository, ILikeRepository likeRepository) {
            this.questionRepository = questionRepository;
            this.likeRepository = likeRepository;
        }

        public async Task AddQuestion(Guid roomId, Guid userId, string text)
        {
            Question question = new Question(roomId, userId, text);
            questionRepository.Create(question);

            await Clients.All.SendAsync("NewQuestionAdded", question);
        }

        public async Task DeleteQuestion(Guid questionId)
        {
            questionRepository.Delete(questionId);

            await Clients.All.SendAsync("QuestionDeleted", questionId);
        }

        public async Task LikeQuestion(Guid questionId, Guid userId)
        {
            Like like = new Like(questionId, userId);
            likeRepository.Create(like);

            Question question = questionRepository.Read(questionId);
            question.Likes = question.Likes + 1;
            questionRepository.Update(question);

            await Clients.All.SendAsync("QuestionLiked", questionId);
        }

        public async Task UnlikeQuestion(Guid questionId, Guid userId)
        {
            likeRepository.Delete(questionId, userId);

            Question question = questionRepository.Read(questionId);
            question.Likes = question.Likes + 1;
            questionRepository.Update(question);

            await Clients.All.SendAsync("QuestionLiked", questionId);
        }

        public async Task MarkQuestionAsRead(Guid questionId)
        {
            Question question = questionRepository.Read(questionId);
            question.Read = true;
            
            questionRepository.Update(question);

            await Clients.All.SendAsync("QuestionMarkedAsRead", questionId);
        }

        public async Task MarkQuestionAsLive(Guid questionId)
        {
            Question question = questionRepository.Read(questionId);
            question.Live = true;

            questionRepository.Update(question);

            await Clients.All.SendAsync("QuestionMarkedAsLive", questionId);
        }
    }
}