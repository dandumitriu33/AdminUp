using AdminUp.DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Models
{
    public class MonthlyExpensesViewModel
    {
        public string Month { get; set; }
        public Building Building { get; set; }
        public List<Appartment> Appartments { get; set; }
        public List<Bill> Bills { get; set; }
        public int TotalInhabitants { get; set; }
    }
}
