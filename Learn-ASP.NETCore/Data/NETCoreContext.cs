using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Learn_ASP.NETCore.Models.Learn_ASP
{
    public class NETCoreContext : DbContext
    {
        public NETCoreContext (DbContextOptions<NETCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
