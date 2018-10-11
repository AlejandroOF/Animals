using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalsData.Entities;
using AnimalsService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetService _service;

        public PetController(IPetService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll()
        {
            var geta = _service.GetAll();
            return geta;
        }


        [HttpGet("{id:int}")]
        public ActionResult<Pet> GetById(int id)
        {

            var getb = _service.GetById(id);
            return getb;
        }

        [HttpPost]
        public IActionResult Create(Pet item)
        {

            var id = _service.Create(item);
            return CreatedAtRoute("GetPet", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pet item)
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
