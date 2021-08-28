using System;
using BackEnd.Entities;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("question")]
    public class Questionontroller : ControllerBase
    {
        private IQuestionRepository repository;

        public Questionontroller(IQuestionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{roomId}")]
        public ActionResult Read(Guid roomId)
        {
            var questions = repository.ReadAll(roomId);
            return Ok(questions);
        }
    }
}