using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsService.Models
{
    public class UserVm
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public List<Petvm> Pets { get; set; }
    }
}
