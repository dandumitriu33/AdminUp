using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Building
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        public int AdministratorId { get; set; }
    }
}
