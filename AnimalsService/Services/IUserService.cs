using AnimalsData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnimalsService.Services;


namespace AnimalsService.Services
{
   public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        void Delete(int id);

        int Create(User item);

        void Update(int id, User item);
    }
}
