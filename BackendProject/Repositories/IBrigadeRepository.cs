using BackendProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Repositories
{
    public interface IBrigadeRepository
    {
        IEnumerable<Brigade> GetBrigade(int Id);
        IEnumerable<Brigade> GetAllBrigade();
    }
}
