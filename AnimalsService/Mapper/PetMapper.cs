using AnimalsData.Entities;
using AnimalsService.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace AnimalsService.Mapper
{
    public class PetMapper : IPetMapper<Pet, PetVm>
    {
        public Pet MaptoEntetity(PetVm model)
        {

            Pet pet = new Pet();

            pet.Id = model.Id;

            pet.Name = model.Name;

            pet.DateOfBirth = model.Dob;

            pet.UserId = model.UserId;

            return pet;

        }

        public IEnumerable<Pet> MapToEntities(IEnumerable<PetVm> models)
        {
            return models.Select(MaptoEntetity);
        }

        public IEnumerable<PetVm> MapToModels(IEnumerable<Pet> entities)
        {
           
            return entities.Select(MapToModel);
        }

        public PetVm MapToModel(Pet entity)
        {
            var petVm = new PetVm();
            petVm.Vaccines = new List<VaccineVm>();

            petVm.Id = entity.Id;

            petVm.Name = entity.Name;

            petVm.Dob = entity.DateOfBirth;

            petVm.UserId = entity.UserId;

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
