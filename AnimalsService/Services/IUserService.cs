using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnimalsService.Services;
using AnimalsService.Models;


namespace AnimalsService.Services
{
   public interface IUserService
    {
        List<UserVm> GetAll();

        UserVm GetById(int id);

        void Delete(int id);

        int Create(UserVm item);

        void Update(int id, UserVm item);
    }
}
