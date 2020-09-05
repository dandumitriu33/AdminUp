using System.Collections.Generic;

namespace AdminUp.DataAccessLibrary.Models
{
    public interface IRepository
    {
        IEnumerable<Appartment> GetAllAppartments();
        Building GetBuildingById(int buildingId);
        List<Bill> GetAllBillsByBuildingId(int buildingId);
        void AddAppartmentOwner(AppartmentOwner appartmentOwner);
        string GetAppartmentOwnerFirstNameById(string appartmentOwnerId);
        string GetAppartmentOwnerLastNameById(string appartmentOwnerId);
    }
}