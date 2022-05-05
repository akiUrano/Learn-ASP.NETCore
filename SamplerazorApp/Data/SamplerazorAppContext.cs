using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SamplerazorApp.Models
{
    public class SamplerazorAppContext : DbContext
    {
        public SamplerazorAppContext (DbContextOptions<SamplerazorAppContext> options)
            : base(options)
        {
        }

        public DbSet<SamplerazorApp.Models.Person> Person { get; set; }
    }
}
