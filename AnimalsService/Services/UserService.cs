using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;


namespace AnimalsService.Services
{
    public class UserService : IUserService
    {
        private readonly AnimalsContext _context;

        public UserService(AnimalsContext context)
        {
            _context = context;
        }

        public int Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();

            return item.Id;
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

        public List<User> GetAll()
        {
            var items = _context.Users.Include(x => x.Pets).ToList();
            return items;
        }

        public User GetById(int id)
        {
            var item = _context.Users.Include(x => x.Pets)

                .SingleOrDefault(x => x.Id == id);

            return item;

        }

        public void Update(int id, User item)
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
