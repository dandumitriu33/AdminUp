using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Appartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BuildingId { get; set; }
        [ForeignKey("AspNetUsers")]
        public string OwnerId { get; set; }
        public int NumberOfInhabitants { get; set; }

    }
}
