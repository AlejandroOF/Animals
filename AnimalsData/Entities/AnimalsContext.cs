using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace AnimalsData.Entities
{
    public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        public DbSet<PetVaccine> PetVaccines { get; set; }
    }
}
