using System;
using System.Collections.Generic;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AdministratorId { get; set; }
    }
}
