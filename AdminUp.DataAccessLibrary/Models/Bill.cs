using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string IssuerName { get; set; }
        [Column(TypeName = ("money"))]
        public decimal Total { get; set; }
        [MaxLength(20)]
        public string Month { get; set; }
        public int BuildingId { get; set; }
    }
}
