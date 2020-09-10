using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class AppartmentModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        public string AppartmentOwnerId { get; set; }
        public int NumberOfInhabitants { get; set; }
    }
}
