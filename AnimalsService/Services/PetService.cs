using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AnimalsData.Entities;
using AnimalsService.Mapper;
using AnimalsService.Models;

namespace AnimalsService.Services
{
    public class PetService : IPetService
    {
        private readonly AnimalsContext _context;
        private readonly IPetMapper<Pet, Petvm> _mapper;

        public PetService(AnimalsContext context, IPetMapper<Pet,Petvm> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(Petvm item)
        {
            var ent = _mapper.MaptoEntetity(item);
            _context.Pets.Add(ent);
            _context.SaveChanges();

            return ent.Id;
        }

        public void Delete(int id)
        {
            var todo = _context.Pets.Find(id);
            if (todo == null)
            {
                return;
            }

            _context.Pets.Remove(todo);
            _context.SaveChanges();
        }

        public List<Petvm> GetAll()
        {
            var ent = _context.Pets.ToList();
            return _mapper.MapToModels(ent).ToList();
        }

        public Petvm GetById(int id)
        {
           
            var item = _context.Pets 
                    .Include(x => x.AnimalType)
                    .Include(x => x.PetVaccines)
                        .ThenInclude(x => x.Vaccine)
                    .SingleOrDefault(x => x.Id == id);

            return _mapper.MapToModel(item);

        }

        public void Update(int id, Petvm item)
        {
             var ent = _mapper.MaptoEntetity(item);
            

            var todo = _context.Pets.Find(id);
            if (todo == null)
            {
                return;
            }

            todo.Name = ent.Name;

            //var ent2 = _mapper.MaptoEntetity(todo); 

            _context.Pets.Update(todo);
            _context.SaveChanges();

            return;
        }
    }
}
