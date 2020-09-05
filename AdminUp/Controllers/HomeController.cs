﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdminUp.Models;
using AdminUp.DataAccessLibrary.DataAccess;
using AdminUp.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminUp.Controllers
{
    // enable after testing [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger,
                              IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // some information is hardcoded until mechanisms are implemented

            MonthlyExpensesViewModel output = new MonthlyExpensesViewModel();
            output.Month = "AUGUST";
            output.Year = 2020;
            output.Building = _repository.GetBuildingById(2);
            List<Appartment> allAppartments = _repository.GetAllAppartments().ToList();
            output.Appartments = allAppartments;
            List<Bill> allBills = _repository.GetAllBillsByBuildingId(2);
            output.Bills = allBills;
            foreach (var appt in allAppartments)
            {
                output.TotalInhabitants += appt.NumberOfInhabitants;
            }
            return View(output);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
