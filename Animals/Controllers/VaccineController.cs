using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;
using AnimalsService.Services;
using AnimalsService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : Controller
    {
        private readonly IVaccine _service;

        public VaccineController(IVaccine service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<VaccineVm>> GetAll()
        {
            var geta = _service.GetAll();
            return geta;
        }


        [HttpGet("{id}", Name = "GetVaccine")]
        public ActionResult<VaccineVm> GetById(int id)
        {

            var getb = _service.GetById(id);
            return getb;
        }

        [HttpPost]
        public IActionResult Create(VaccineVm item)
        {

            var id = _service.Create(item);
            return CreatedAtRoute("GetVaccine", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VaccineVm item)
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
