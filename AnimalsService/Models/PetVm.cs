using System;
using System.Collections.Generic;
using System.Text;
using AnimalsData.Entities;

namespace AnimalsService.Models
{
    public class Petvm
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AnimalTypeId { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }   

        public List<VaccineVm> Vaccines { get; set; }

       
    }
}
