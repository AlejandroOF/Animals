using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsData.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int UserId { get; set; }

        public int AnimalTypeId { get; set; }

        public AnimalType AnimalType { get; set; }

        public List<PetVaccine> PetVaccines { get; set; }

    }
}
