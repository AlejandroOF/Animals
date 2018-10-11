using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalsData.Entities;
using AnimalsService.Models;

namespace AnimalsService.Mapper
{
    public class VaccineMapper : IVaccineMapper<Vaccine, VaccineVm>
    {
        public IEnumerable<Vaccine> MapToEntities(IEnumerable<VaccineVm> models)
        {
            return models.Select(MaptoEntity);
        }

        public Vaccine MaptoEntity(VaccineVm model)
        {
            var vaccine = new Vaccine();

            vaccine.Id = model.Id;

            vaccine.Name = model.Name;

            return vaccine;
        }

        public VaccineVm MapToModel(Vaccine entity)
        {
            var vaccineVm = new VaccineVm();

            vaccineVm.Id = entity.Id;

            vaccineVm.Name = entity.Name;

            if (entity.Id == 0)
            {
                return vaccineVm;
            }


            return vaccineVm;
        }

        public IEnumerable<VaccineVm> MapToModels(IEnumerable<Vaccine> entities)
        {
            return entities.Select(MapToModel);
        }
    }
}
