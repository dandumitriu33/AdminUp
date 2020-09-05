using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class AppartmentViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        [ForeignKey("AspNetUsers")]
        public string AppartmentOwnerId { get; set; }
        public string AppartmentOwnerFirstName { get; set; }
        public string AppartmentOwnerLastName { get; set; }
        public int NumberOfInhabitants { get; set; }
    }
}
