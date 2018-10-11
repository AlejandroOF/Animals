using System;
using System.Collections.Generic;
using System.Text;
using AnimalsService.Models;
using AnimalsData.Entities;

namespace AnimalsService.Mapper
{
    public interface IVaccineMapper<Vaccine, VaccineVm>
    {
        Vaccine MaptoEntity(VaccineVm model);

        VaccineVm MapToModel(Vaccine entity);

        IEnumerable<Vaccine> MapToEntities(IEnumerable<VaccineVm> models);

        IEnumerable<VaccineVm> MapToModels(IEnumerable<Vaccine> entities);
    }
}
