using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SamplerazorApp.Models;

namespace SamplerazorApp.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly SamplerazorApp.Models.SamplerazorAppContext _context;

        public IndexModel(SamplerazorApp.Models.SamplerazorAppContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _context.Person.ToListAsync();
        }
    }
}
