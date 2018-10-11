using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Models
{
    public class AnimalTypeVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Petvm> Pets { get; set; }
    }
}
