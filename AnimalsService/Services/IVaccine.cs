using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalsService.Models;

namespace AnimalsService.Services
{
    public interface IVaccine
    {
        List<VaccineVm> GetAll();

        VaccineVm GetById(int id);

        void Delete(int id);

        int Create(VaccineVm item);

        void Update(int id, VaccineVm item);
    }
}
