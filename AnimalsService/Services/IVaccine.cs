using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Services
{
    public interface IVaccine
    {
        List<Vaccine> GetAll();

        Vaccine GetById(int id);

        void Delete(int id);

        int Create(Vaccine item);

        void Update(int id, Vaccine item);
    }
}
