using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Services
{
    public interface IAnimalTypeService
    {
        List<AnimalType> GetAll();

        AnimalType GetById(int id);

        void Delete(int id);

        int Create(AnimalType item);

        void Update(int id, AnimalType item);
    }
}
