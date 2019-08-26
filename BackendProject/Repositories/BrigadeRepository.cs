using BackendProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Repositories
{
    public class BrigadeRepository : IBrigadeRepository
    {
        private readonly DBTestContext _context;

        public BrigadeRepository(DBTestContext context)
        {
            _context = context;
        }

        public IEnumerable<Brigade> GetAllBrigade()
        {
            return _context.Brigade.FromSql("[dbo].[GetAllBrigade]");
        }

        public IEnumerable<Brigade> GetBrigade(int Id)
        {
            var brigadeId = new SqlParameter("Id", Id);
            return _context.Brigade.FromSql("[dbo].[GetBrigade] @Id", brigadeId);
        }
    }
}
