﻿using AdminUp.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminUp.DataAccessLibrary.DataAccess
{
    public class AdminUpContext : IdentityDbContext // it chain implements DbContext
    {
        public AdminUpContext(DbContextOptions options) : base(options) { }

        public DbSet<AppartmentOwner> AppartmentOwners { get; set; }
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
    }
}
