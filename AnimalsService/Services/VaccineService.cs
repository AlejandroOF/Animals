using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;
using AnimalsService.Mapper;
using AnimalsService.Models;



namespace AnimalsService.Services
{
    public class VaccineService : IVaccine
    {
        public readonly AnimalsContext _context;
        public readonly IVaccineMapper<Vaccine, VaccineVm> _mapper;

        public VaccineService(AnimalsContext context, IVaccineMapper<Vaccine, VaccineVm> mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(VaccineVm item)
        {
            var ent = _mapper.MaptoEntity(item);
            _context.Vaccines.Add(ent);
            _context.SaveChanges();

            return ent.Id;
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

        public List<VaccineVm> GetAll()
        {
            var get = _context.Vaccines.ToList();

            return _mapper.MapToModels(get).ToList();
        }

        public VaccineVm GetById(int id)
        {
            var item = _context.Vaccines.Find(id);

            return _mapper.MapToModel(item);
        }

        public void Update(int id, VaccineVm item)
        {
            var ent = _mapper.MaptoEntity(item);

            var vaccine = _context.Vaccines.Any(x => x.Id == id);
            if(!vaccine)
            {
                return;
            }
            ent.Id = id;

            _context.Vaccines.Update(ent);
            _context.SaveChanges();
            return;
        }
    }
}
