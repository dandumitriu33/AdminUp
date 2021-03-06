﻿using AdminUp.DataAccessLibrary.DataAccess;
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

        public IEnumerable<Building> GetAllBuildings()
        {
            return _context.Buildings;
        }

        public IEnumerable<Appartment> GetAllAppartments()
        {
            return _context.Appartments;
        }

        public IEnumerable<Appartment> GetAllAppartmentsByBuildingId(int buildingId)
        {
            // hardcoded building id 2 to remove after full implement
            buildingId = 2;

            return _context.Appartments.Where(a => a.BuildingId == buildingId).OrderBy(a => a.Number).ToList();
        }

        public Building GetBuildingById(int buildingId)
        {
            return _context.Buildings.Where(building => building.Id == buildingId).FirstOrDefault();
        }

        public List<Bill> GetAllBillsByBuildingId(int buildingId)
        {
            return _context.Bills.Where(bill => bill.BuildingId == buildingId).ToList();
        }

        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public Bill GetBillById(int billId)
        {
            Bill billFromDb = _context.Bills.Where(bill => bill.Id == billId).FirstOrDefault();
            return billFromDb;
        }

        public void UpdateBill(Bill billFromForm)
        {
            var result = _context.Bills.Where(b => b.Id == billFromForm.Id).FirstOrDefault();

            if (result != null)
            {
                result.IssuerName = billFromForm.IssuerName;
                result.Month = billFromForm.Month;
                result.BuildingId = billFromForm.BuildingId;
                result.Total = billFromForm.Total;
                _context.SaveChanges();
            }
        }

        public void DeleteBillById(int billId)
        {
            var result = _context.Bills.Where(b => b.Id == billId).FirstOrDefault();
            _context.Bills.Remove(result);
            _context.SaveChanges();
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

        public List<Announcement> GetAllAnnouncementsByBuildingId(int buildingId)
        {
            return _context.Announcements.Where(a => a.BuilidingId == buildingId).OrderByDescending(a => a.DateAdded).ToList();
        }

        public void AddAnnouncement(int buildingId, string announcementMessage)
        {
            Announcement newAnnouncement = new Announcement
            {
                BuilidingId = buildingId,
                Message = announcementMessage
            };
            _context.Announcements.Add(newAnnouncement);
            _context.SaveChanges();
        }
    }
}
