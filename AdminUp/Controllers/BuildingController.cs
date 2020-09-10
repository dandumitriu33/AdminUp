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
    }
}
