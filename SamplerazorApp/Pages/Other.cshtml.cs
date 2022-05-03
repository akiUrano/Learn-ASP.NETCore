using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SamplerazorApp.Pages
{
    public class OtherModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Message = "you typed:" + Request.Form["msg"];
        }
    }
}
