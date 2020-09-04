using System;
using System.Collections.Generic;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Appartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        public int OwnerId { get; set; }
        public int NumberOfInhabitants { get; set; }

    }
}
