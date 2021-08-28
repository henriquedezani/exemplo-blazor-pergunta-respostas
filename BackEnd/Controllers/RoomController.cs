using System;
using BackEnd.Entities;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private IRoomRepository repository;

        public RoomController(IRoomRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            room.UserId = Guid.NewGuid();
            repository.Create(room);
            return Ok(room);
        }

        [HttpGet]
        public ActionResult Read(Guid roomId)
        {
            Room room = repository.Read(roomId);
            return Ok(room);
        }

        [HttpPut]
        public ActionResult Update(Guid roomId, [FromQuery]bool status)
        {
            Room room = repository.Read(roomId);
            room.Active = status;

            repository.Update(room);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(Guid roomId)
        {
            repository.Delete(roomId);
            return Ok();
        }
    }
}