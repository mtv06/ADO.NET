using BackendProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendProject.Repositories
{
    public interface IClaimRepository
    {
        IEnumerable<Claim> GetClaim(int Id);
        IEnumerable<Claim> GetAllClaim();
        void AddClaim(Claim claim);
        void UpdateClaim(int Id, Claim claim);
        void RemoveClaim(int Id);
    }
}
