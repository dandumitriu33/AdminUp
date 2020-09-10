using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public string IssuerName { get; set; }
        public decimal Total { get; set; }
        public string Month { get; set; }
        public int BuildingId { get; set; }
    }
}
