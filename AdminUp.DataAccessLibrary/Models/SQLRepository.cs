using AdminUp.DataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
