using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalsData.Entities;
using AnimalsService.Services;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : Controller
    {
        private readonly IAnimalTypeService _service;

        public AnimalTypeController(IAnimalTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<AnimalType>> GetAll()
        {
            var geta = _service.GetAll();
            return geta;
        }


        [HttpGet("{id}", Name = "GetAnimalType")]
        public ActionResult<AnimalType> GetById(int id)
        {

            var getb = _service.GetById(id);
            return getb;
        }

        [HttpPost]
        public IActionResult Create(AnimalType item)
        {

            var id = _service.Create(item);
            return CreatedAtRoute("GetAnimalType", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, AnimalType item)
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
