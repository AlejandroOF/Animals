using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AnimalsService.Mapper
{
    public interface IPetMapper<Pet,PetVm>
    {
        Pet MaptoEntetity(PetVm model);

        PetVm MapToModel(Pet entity);

        IEnumerable<Pet> MapToEntities(IEnumerable<PetVm> models);

        IEnumerable<PetVm> MapToModels(IEnumerable<Pet> entities);
    }
}
