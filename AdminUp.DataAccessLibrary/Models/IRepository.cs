﻿using System.Collections.Generic;

namespace AdminUp.DataAccessLibrary.Models
{
    public interface IRepository
    {
        IEnumerable<Building> GetAllBuildings();
        IEnumerable<Appartment> GetAllAppartments();
        IEnumerable<Appartment> GetAllAppartmentsByBuildingId(int buildingId);
        Building GetBuildingById(int buildingId);
        List<Bill> GetAllBillsByBuildingId(int buildingId);
        void AddBill(Bill bill);
        Bill GetBillById(int billId);
        void UpdateBill(Bill bill);
        void DeleteBillById(int billId);
        void AddAppartmentOwner(AppartmentOwner appartmentOwner);
        string GetAppartmentOwnerFirstNameById(string appartmentOwnerId);
        string GetAppartmentOwnerLastNameById(string appartmentOwnerId);
        List<Announcement> GetAllAnnouncementsByBuildingId(int buildingId);
        void AddAnnouncement(int buildingId, string announcementMessage);
    }
}