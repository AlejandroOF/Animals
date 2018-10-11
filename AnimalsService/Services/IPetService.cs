using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalsService.Models;

namespace AnimalsService.Services
{
   public interface IPetService
    {
        List<Petvm> GetAll();

        Petvm GetById(int id);

        void Delete(int id);

        int Create(Petvm item);

        void Update(int id, Petvm item);
    }
}
