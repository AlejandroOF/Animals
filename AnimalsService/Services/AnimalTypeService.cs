using System;
using System.Collections.Generic;
using System.Text;
using AnimalsData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimalsService.Services
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly AnimalsContext _context;

        public AnimalTypeService(AnimalsContext context)
        {
            _context = context;
        }

        public int Create(AnimalType item)
        {
            _context.AnimalTypes.Add(item);
            _context.SaveChanges();

            return item.Id;
        }

        public void Delete(int id)
        {
            var todo = _context.AnimalTypes.Find(id);
            if (todo == null)
            {
                return;
            }

            _context.AnimalTypes.Remove(todo);
            _context.SaveChanges();
        }

        public List<AnimalType> GetAll()
        {
            return _context.AnimalTypes.ToList();
        }

        public AnimalType GetById(int id)
        {
            var item = _context.AnimalTypes.Include(x => x.Pets)

                .SingleOrDefault(x => x.Id == id);

            return item;
        }

        public void Update(int id, AnimalType item)
        {
            var todo = _context.AnimalTypes.Find(id);
            if (todo == null)
            {
                return;
            }

            todo.Name = item.Name;

            _context.AnimalTypes.Update(todo);
            _context.SaveChanges();
            return;
        }
    }
}
