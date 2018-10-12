using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalsData.Entities;


namespace AnimalsService.Services
{
    public class PetVaccineService : IPetVaccine
    {
        private readonly AnimalsContext _context;

        public PetVaccineService(AnimalsContext context)
        {
            _context = context;
        }

        public int Create(PetVaccine item)
        {
            _context.PetVaccines.Add(item);
            _context.SaveChanges();

            return item.Id;
        }

        public void Delete(int id)
        {
            var todo = _context.PetVaccines.Find(id);
            if (todo == null)
            {
                return;
            }

            _context.PetVaccines.Remove(todo);
            _context.SaveChanges();
        }

        public List<PetVaccine> GetAll()
        {
            return _context.PetVaccines.ToList();
        }

        public PetVaccine GetById(int id)
        {
            var item = _context.PetVaccines.Find(id);

            return item;
        }

        public void Update(int id, PetVaccine item)
        {
            var todo = _context.PetVaccines.Find(id);
            if (todo == null)
            {
                return;
            }
            
            _context.PetVaccines.Update(todo);
            _context.SaveChanges();
            return;
        }
    }
}
