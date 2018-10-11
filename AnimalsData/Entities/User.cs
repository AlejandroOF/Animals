using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalsData.Entities
{
   public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public List<Pet> Pets { get; set; }

       // public List<AnimalType> AnimalTypes { get; set; }
    }
}
