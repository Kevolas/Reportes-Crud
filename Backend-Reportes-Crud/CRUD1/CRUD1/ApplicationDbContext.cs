using CRUD1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD1
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<ReporteModel> Reportes { get; set; }

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options): base(options)
        {

        }
    }
}
