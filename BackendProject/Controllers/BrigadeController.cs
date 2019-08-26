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
    public class BrigadeController : ControllerBase
    {
        private readonly IBrigadeRepository _brigadeRepository;

        public BrigadeController(IBrigadeRepository brigadeRepository)
        {
            _brigadeRepository = brigadeRepository;
        }

        // GET: api/Brigade
        [HttpGet]
        public IEnumerable<Brigade> GetBrigade()
        {
            return _brigadeRepository.GetAllBrigade();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public IEnumerable<Brigade> GetBrigade([FromRoute] int id)
        {
            return _brigadeRepository.GetBrigade(id);
        }

    }
}