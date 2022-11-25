using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP.netAPI.Models;

namespace webApi.Data
{
    public class webApiContext : DbContext
    {
        public webApiContext (DbContextOptions<webApiContext> options)
            : base(options)
        {
        }

        public DbSet<ASP.netAPI.Models.Product> Product { get; set; }
    }
}
