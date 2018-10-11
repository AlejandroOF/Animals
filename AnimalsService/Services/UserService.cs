using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;
using AnimalsService.Mapper;
using AnimalsService.Models;


namespace AnimalsService.Services
{
    public class UserService : IUserService
    {
        private readonly AnimalsContext _context;
        private readonly IUserMapper<User, UserVm> _mapper;

        public UserService(AnimalsContext context, IUserMapper<User, UserVm> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(UserVm item)
        {
            var ent = _mapper.MaptoEntity(item);

            _context.Users.Add(ent);
            _context.SaveChanges();

            return ent.Id;
        }

        public void Delete(int id)
        {

            var todo = _context.Users.Find(id);
            if (todo == null)
            {
                return;
            }

            _context.Users.Remove(todo);
            _context.SaveChanges();
        }

        public List<UserVm> GetAll()
        {
            var get = _context.Users.ToList();

            return _mapper.MapToModels(get).ToList();
        }

        public UserVm GetById(int id)
        {
            var item = _context.Users.Include(x => x.Pets)

                .SingleOrDefault(x => x.Id == id);

            return _mapper.MapToModel(item);

        }

        public void Update(int id, UserVm item)
        {

            var todo = _context.Users.Find(id);
            if (todo == null)
            {
                return;
            }

            todo.Username = item.Username;

            _context.Users.Update(todo);
            _context.SaveChanges();
            return;
        }
    }
}
