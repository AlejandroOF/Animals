using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;

namespace AnimalsService.Services
{
    public class PetService : IPetService
    {
        private readonly AnimalsContext _context;

        public PetService(AnimalsContext context)
        {
            _context = context;
        }

        public int Create(Pet item)
        {
            _context.Pets.Add(item);
            _context.SaveChanges();

            return item.Id;
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

        public List<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet GetById(int id)
        {

            var item = _context.Pets
                    .Include(x => x.AnimalType)
                    .Include(x => x.PetVaccines)
                        .ThenInclude(x => x.Vaccine)
                    .SingleOrDefault(x => x.Id == id);
            return item;

        }

        public void Update(int id, Pet item)
        {
            var todo = _context.Pets.Find(id);
            if (todo == null)
            {
                return;
            }

            todo.Name = item.Name;

            _context.Pets.Update(todo);
            _context.SaveChanges();
            return;
        }
    }
}
