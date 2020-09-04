﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdminUp.DataAccessLibrary.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string IssuerName { get; set; }
        public decimal Total { get; set; }
        public string Month { get; set; }
        public int BuildingId { get; set; }
    }
}