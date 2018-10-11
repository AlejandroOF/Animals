using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsData.Entities
{
    public class AnimalType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Pet> Pets { get; set; }

        public List<User> Users { get; set; }

    }
}
