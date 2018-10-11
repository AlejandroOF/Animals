using System;
using System.Collections.Generic;
using System.Text;
using AnimalsData.Entities;
using AnimalsService.Models;

namespace AnimalsService.Mapper
{
    public interface IUserMapper<User,UserVm>
    {
        User MaptoEntity(UserVm model);

        UserVm MapToModel(User entity);

        IEnumerable<User> MapToEntities(IEnumerable<UserVm> models);

        IEnumerable<UserVm> MapToModels(IEnumerable<User> entities);
    }
}
