using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Services
{
    public interface IPetVaccine
    {
        List<PetVaccine> GetAll();

        PetVaccine GetById(int id);

        void Delete(int id);

        int Create(PetVaccine item);

        void Update(int id, PetVaccine item);
    }
}
