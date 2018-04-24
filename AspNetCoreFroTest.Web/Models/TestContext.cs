using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFroTest.Web.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
