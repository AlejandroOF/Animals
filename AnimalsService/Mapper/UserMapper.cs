using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AnimalsData.Entities;
using AnimalsService.Models;

namespace AnimalsService.Mapper
{
    public class UserMapper : IUserMapper<User, UserVm>
    {
        public IEnumerable<User> MapToEntities(IEnumerable<UserVm> models)
        {
            return models.Select(MaptoEntity);
        }

        public User MaptoEntity(UserVm model)
        {
            var user = new User();

            user.Id = model.Id;
            user.Username = model.Username;

            return user;
        }

        public UserVm MapToModel(User entity)
        {
            var userVm = new UserVm();
            userVm.Pets = new List<Petvm>();

            userVm.Id = entity.Id;
            userVm.Username = entity.Username;
          
            if (entity.Pets == null)
            {
                return userVm;
            }

            foreach (var item in entity.Pets)
            {
                var petVm = new Petvm();

                petVm.Id = item.Id;
                petVm.Name = item.Name;
                petVm.UserId = item.UserId;
                petVm.AnimalTypeId = item.AnimalTypeId;
                petVm.Dob = item.DateOfBirth;

                userVm.Pets.Add(petVm);
            }

            return userVm;
        }

        public IEnumerable<UserVm> MapToModels(IEnumerable<User> entities)
        {
            return entities.Select(MapToModel);
        }
    }
}
