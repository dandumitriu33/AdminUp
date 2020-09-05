using AdminUp.DataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUp.DataAccessLibrary.Models
{
    public class SQLRepository : IRepository
    {
        private readonly AdminUpContext _context;

        public SQLRepository(AdminUpContext context)
        {
            _context = context;
        }

        public IEnumerable<Appartment> GetAllAppartments()
        {
            return _context.Appartments;
        }

        public Building GetBuildingById(int buildingId)
        {
            return _context.Buildings.Where(building => building.Id == buildingId).FirstOrDefault();
        }

        public List<Bill> GetAllBillsByBuildingId(int buildingId)
        {
            return _context.Bills.Where(bill => bill.BuildingId == buildingId).ToList();
        }

        public void AddAppartmentOwner(AppartmentOwner appartmentOwner)
        {
            _context.AppartmentOwners.Add(appartmentOwner);
            _context.SaveChanges();
        }

        public string GetAppartmentOwnerFirstNameById(string userId)
        {
            var owner = _context.AppartmentOwners.Where(a => a.Id == userId).FirstOrDefault();

            if (owner == null)
            {
                return "";
            }
            return owner.FirstName;
        }

        public string GetAppartmentOwnerLastNameById(string userId)
        {
            var owner = _context.AppartmentOwners.Where(a => a.Id == userId).FirstOrDefault();
            if (owner == null)
            {
                return "";
            }
            return owner.LastName;
        }
    }
}
