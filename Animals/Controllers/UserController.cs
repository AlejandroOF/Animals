using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsData.Entities;
using AnimalsService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var geta = _service.GetAll();
            return geta;
        }


        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(int id)
        {

            var getb = _service.GetById(id);
            return getb;
        }

        [HttpPost]
        public IActionResult Create(User item)
        {

            var id = _service.Create(item);
            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User item)
        {
            _service.Update(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
