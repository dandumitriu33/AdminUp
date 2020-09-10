using System;
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

            List<Announcement> allAnnouncements = _repository.GetAllAnnouncementsByBuildingId(2);
            List<AnnouncementModel> allAnnouncementsForView = new List<AnnouncementModel>();
            foreach (var announcement in allAnnouncements)
            {
                allAnnouncementsForView.Add(new AnnouncementModel
                {
                    Id = announcement.Id,
                    Message = announcement.Message,
                    BuilidingId = announcement.BuilidingId,
                    DateAdded = announcement.DateAdded
                });
            }
            output.Announcements = allAnnouncementsForView;

            List<Appartment> allAppartments = _repository.GetAllAppartments().ToList();
            List<AppartmentViewModel> allAppartmentsIncludingOwnerNames = new List<AppartmentViewModel>();
            foreach (var appt in allAppartments)
            {
                string firstName = _repository.GetAppartmentOwnerFirstNameById(appt.AppartmentOwnerId);
                string lastName = _repository.GetAppartmentOwnerLastNameById(appt.AppartmentOwnerId);
                AppartmentViewModel tempAppt = new AppartmentViewModel
                {
                    Id = appt.Id,
                    AppartmentOwnerId = appt.AppartmentOwnerId,
                    BuildingId = appt.BuildingId,
                    Number = appt.Number,
                    NumberOfInhabitants = appt.NumberOfInhabitants,
                    AppartmentOwnerFirstName = firstName,
                    AppartmentOwnerLastName = lastName
                };
                allAppartmentsIncludingOwnerNames.Add(tempAppt);
            }
            output.Appartments = allAppartmentsIncludingOwnerNames;

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
