using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Context
{
    public class CustomerContext:DbContext
    {

        public CustomerContext(DbContextOptions<CustomerContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> customer { get; set; }

    }
}
