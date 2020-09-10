using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminUp.DataAccessLibrary.Models;
using AdminUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminUp.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IRepository _repository;

        public BuildingController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allBuildings = _repository.GetAllBuildings();
            List<BuildingModel> allBuildingsModels = new List<BuildingModel>();

            foreach (var building in allBuildings)
            {
                allBuildingsModels.Add(new BuildingModel
                {
                    Id = building.Id,
                    Name = building.Name,
                    Address = building.Address,
                    AdministratorId = building.AdministratorId
                });
            }
            return View(allBuildingsModels);
        }

        [HttpGet]
        [Route("building/index/{buildingId}/bills")]
        public IActionResult Bills(int buildingId)
        {
            // hardcoded as 2 for now
            buildingId = 2; // to delete when proper multiple buildings implementation is up
            var allBills = _repository.GetAllBillsByBuildingId(buildingId);
            List<BillModel> allBillsModels = new List<BillModel>();

            foreach (var bill in allBills)
            {
                allBillsModels.Add(new BillModel
                {
                    Id = bill.Id,
                    BuildingId = bill.BuildingId,
                    IssuerName = bill.IssuerName,
                    Month = bill.Month,
                    Total = bill.Total
                });
            }
            return View(allBillsModels);
        }

        [HttpPost]
        public IActionResult AddBill(int buildingId)
        {
            // building id 2 hardcoded until full implementation
            buildingId = 2;
            string billIssuerName = Request.Form["issuerName"];
            string month = Request.Form["month"];
            string total = Request.Form["total"];

            Bill newBill = new Bill
            {
                IssuerName = billIssuerName,
                Month = month,
                BuildingId = buildingId,
                Total = Int32.Parse(total)
            };

            _repository.AddBill(newBill);

            return RedirectToAction("Bills", new { buildingId });
        }

        [HttpGet]
        public IActionResult EditBill(int billId)
        {
            //int billId = int.Parse(Request.Form["billId"]);

            Bill billFromDb = _repository.GetBillById(billId);

            BillModel billToDisplay = new BillModel
            {
                Id = billFromDb.Id,
                BuildingId = billFromDb.BuildingId,
                IssuerName = billFromDb.IssuerName,
                Total = billFromDb.Total,
                Month = billFromDb.Month
            };
            return View(billToDisplay);
        }

        [HttpPost]
        public IActionResult EditBillPost(int buildingId)
        {
            buildingId = Int32.Parse(Request.Form["buildingId"]);


            int newId = Int32.Parse(Request.Form["billId"]);
            string newMonth = Request.Form["month"];
            string newIssuerName = Request.Form["issuerName"];
            int newTotal = Convert.ToInt32(double.Parse(Request.Form["total"]));
            int newBuildingId = Int32.Parse(Request.Form["buildingId"]);
            
            Bill billToUpdateOnDb = new Bill
            {
                Id = newId,
                Month = newMonth,
                IssuerName = newIssuerName,
                Total = newTotal,
                BuildingId = newBuildingId
            };

            _repository.UpdateBill(billToUpdateOnDb);

            return RedirectToAction("Bills", new { buildingId });
        }

        [HttpPost]
        public IActionResult DeleteBill(int buildingId)
        {
            int billId = int.Parse(Request.Form["billId"]);

            _repository.DeleteBillById(billId);

            return RedirectToAction("bills", new { buildingId });
        }

        [HttpGet]
        [Route("building/index/{buildingId}/announcements")]
        public IActionResult Announcements(int buildingId)
        {
            // hardcoded as 2 for now
            buildingId = 2; // to delete when proper multiple buildings implementation is up
            var allAnnouncements = _repository.GetAllAnnouncementsByBuildingId(buildingId);
            List<AnnouncementModel> allAnnouncementsModels = new List<AnnouncementModel>();

            foreach (var announcement in allAnnouncements)
            {
                allAnnouncementsModels.Add(new AnnouncementModel
                {
                    Id = announcement.Id,
                    BuilidingId = announcement.BuilidingId,
                    Message = announcement.Message,
                    DateAdded = announcement.DateAdded
                });
            }
            return View(allAnnouncementsModels);
        }

        [HttpPost]
        public IActionResult AddAnnouncement(int buildingId)
        {
            // hardocded building id 2 to be removed when full implementation is up
            buildingId = 2;

            string announcementMessage = Request.Form["announcementMessage"];
            _repository.AddAnnouncement(buildingId, announcementMessage);

            return RedirectToAction("Announcements", new { buildingId });
        }

        [HttpGet]
        [Route("building/index/{buildingId}/appartments")]
        public IActionResult Appartments(int buildingId)
        {
            // hardcoded as 2 for now
            buildingId = 2; // to delete when proper multiple buildings implementation is up
            var allAppartments = _repository.GetAllAppartmentsByBuildingId(buildingId);
            List<AppartmentModel> allAppartmentsModels = new List<AppartmentModel>();

            foreach (var appartment in allAppartments)
            {
                allAppartmentsModels.Add(new AppartmentModel
                {
                    Id = appartment.Id,
                    Number = appartment.Number,
                    BuildingId = appartment.BuildingId,
                    NumberOfInhabitants = appartment.NumberOfInhabitants,
                    AppartmentOwnerId = appartment.AppartmentOwnerId
                });
            }
            return View(allAppartmentsModels);
        }
    }
}
