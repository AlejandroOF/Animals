using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;



namespace AnimalsService.Services
{
    public class VaccineService : IVaccine
    {
        public readonly AnimalsContext _context;

        public VaccineService(AnimalsContext context)
        {
            _context = context;
        }
        public int Create(Vaccine item)
        {
            _context.Vaccines.Add(item);
            _context.SaveChanges();

            return item.Id;
        }

        public void Delete(int id)
        {
            var vaccine = _context.Vaccines.Find(id);
            if (vaccine == null)
            {
                return;
            }

            _context.Vaccines.Remove(vaccine);
            _context.SaveChanges();
        }

        public List<Vaccine> GetAll()
        {
            return _context.Vaccines.ToList();
        }

        public Vaccine GetById(int id)
        {
            var item = _context.Vaccines.Find(id);

            return item;
        }

        public void Update(int id, Vaccine item)
        {
            var vaccine = _context.Vaccines.Find(id);
            if(vaccine == null)
            {
                return;
            }

            vaccine.Name = item.Name;

            _context.Vaccines.Update(vaccine);
            _context.SaveChanges();
            return;
        }
    }
}
