using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProject.Models
{
    public class DBTestContext : DbContext
    {
        public DBTestContext(DbContextOptions<DBTestContext> options) : base(options)
        {

        }

        public DbSet<Claim> Claim { get; set; }
        public DbSet<Brigade> Brigade { get; set; }
        public DbSet<Task> Task { get; set; }

    }
}
