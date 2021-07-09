using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Context
{
    public class MedicineContext:DbContext
    {

        public MedicineContext(DbContextOptions<MedicineContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Medicine> medicine { get; set; }

    }
}
