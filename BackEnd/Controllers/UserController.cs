using System;
using BackEnd.Entities;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.UserId = Guid.NewGuid();
            repository.Create(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Read(string email, string password)
        {
            User user = repository.Read(email, password);

            if(user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [HttpGet]
        public ActionResult Read(Guid userId)
        {
            User user = repository.Read(userId);
            return Ok(user);
        }

        [HttpPut]
        public ActionResult Update(User user)
        {
            repository.Update(user);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(Guid userId)
        {
            repository.Delete(userId);
            return Ok();
        }
    }
}