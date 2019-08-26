using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BackendProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly DBTestContext _context;

        public ClaimRepository(DBTestContext context)
        {
            _context = context;
        }

        public void AddClaim(Claim claim)
        {
            var ClaimDate = new SqlParameter("ClaimDate", claim.ClaimDate);
            var ClaimNumber = new SqlParameter("ClaimNumber", claim.ClaimNumber);
            var Customer = new SqlParameter("Customer", claim.Customer);
            var CustomerRequisites = new SqlParameter("CustomerRequisites", claim.CustomerRequisites);
            var ListWorks = new SqlParameter("ListWorks", claim.ListWorks);
            _context.Database.ExecuteSqlCommand("[dbo].[AddClaim] @ClaimDate, @ClaimNumber, @Customer, @CustomerRequisites, @ListWorks", ClaimDate, ClaimNumber, Customer, CustomerRequisites, ListWorks);
        }

        public void RemoveClaim(int Id)
        {
            var claimId = new SqlParameter("Id", Id);
            _context.Database.ExecuteSqlCommand("[dbo].[RemoveClaim] @Id", claimId);
        }

        public IEnumerable<Claim> GetAllClaim()
        {
            return _context.Claim.FromSql("[dbo].[GetAllClaim]");
        }

        public IEnumerable<Claim> GetClaim(int Id)
        {
            var claimId = new SqlParameter("Id", Id);
            return _context.Claim.FromSql("[dbo].[GetClaim] @Id", claimId);
        }

        public void UpdateClaim(int Id, Claim claim)
        {
            var claimId = new SqlParameter("Id", Id);
            var ClaimDate = new SqlParameter("ClaimDate", claim.ClaimDate);
            var ClaimNumber = new SqlParameter("ClaimNumber", claim.ClaimNumber);
            var Customer = new SqlParameter("Customer", claim.Customer);
            var CustomerRequisites = new SqlParameter("CustomerRequisites", claim.CustomerRequisites);
            var ListWorks = new SqlParameter("ListWorks", claim.ListWorks);
            _context.Database.ExecuteSqlCommand("[dbo].[UpdateClaim] @Id, @ClaimDate, @ClaimNumber, @Customer, @CustomerRequisites, @ListWorks", claimId, ClaimDate, ClaimNumber, Customer, CustomerRequisites, ListWorks);
        }
    }
}
