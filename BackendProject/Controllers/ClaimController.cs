using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendProject.Models;
using BackendProject.Repositories;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        // GET: api/Claim
        [HttpGet]
        public IEnumerable<Claim> GetClaim()
        {
            return _claimRepository.GetAllClaim();
        }

        // GET: api/Claim/5
        [HttpGet("{id}")]
        public IEnumerable<Claim> GetClaim([FromRoute] int id)
        {
            return _claimRepository.GetClaim(id);
        }

        // POST: api/Claim
        [HttpPost]
        public void PostClaim([FromBody] Claim claim)
        {
            _claimRepository.AddClaim(claim);
        }

        // DELETE: api/Claim/5
        [HttpDelete("{id}")]
        public void DeleteClaim([FromRoute] int id)
        {
            _claimRepository.RemoveClaim(id);
        }

        // PUT: api/Claim/5
        [HttpPut("{id}")]
        public void PutClaim([FromRoute] int id, [FromBody] Claim claim)
        {
            _claimRepository.UpdateClaim(id, claim);
        }
    }
}