using AnimalsData.Entities;
using AnimalsService.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsService.Mapper
{
    public class PetMapper : IPetMapper<Pet, Petvm>
    {
        public Pet MaptoEntetity(Petvm model)
        {
            var pet = new Pet();

            pet.Id = model.Id;
            pet.Name = model.Name;
            pet.DateOfBirth = model.Dob;
            pet.UserId = model.UserId;
            pet.AnimalTypeId = model.AnimalTypeId;

            return pet;
        }

        public IEnumerable<Pet> MapToEntities(IEnumerable<Petvm> models)
        {
            return models.Select(MaptoEntetity);
        }

        public IEnumerable<Petvm> MapToModels(IEnumerable<Pet> entities)
        {
            return entities.Select(MapToModel);
        }

        public Petvm MapToModel(Pet entity)
        {
            var petVm = new Petvm();
            petVm.Vaccines = new List<VaccineVm>();

            petVm.Id = entity.Id;
            petVm.Name = entity.Name;
            petVm.Dob = entity.DateOfBirth;
            petVm.UserId = entity.UserId;
            petVm.AnimalTypeId = entity.AnimalTypeId;

            if(entity.PetVaccines == null)
            {
                return petVm;
            }

            foreach (var item in entity.PetVaccines)
            {
                var vaccineVm = new VaccineVm();
                vaccineVm.Name = item.Vaccine.Name;
                vaccineVm.AppliedDate = item.Date;

                petVm.Vaccines.Add(vaccineVm);
            }

            return petVm;
        }
    }
}
