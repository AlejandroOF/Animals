using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsData.Entities
{
    public class PetVaccine
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int VaccineId { get; set; }

        public Vaccine Vaccine { get; set; }
    }
}
    