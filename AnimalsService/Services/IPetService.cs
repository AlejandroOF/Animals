using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Services
{
   public interface IPetService
    {
        List<Pet> GetAll();

        Pet GetById(int id);

        void Delete(int id);

        int Create(Pet item);

        void Update(int id, Pet item);
    }
}
