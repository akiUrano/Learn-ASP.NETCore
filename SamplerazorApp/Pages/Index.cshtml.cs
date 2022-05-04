using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamplerazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [ViewData]
        public string Message { get; set; } = "sample message";
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        private string[][] data = new string[][]
        {
            new string []{"Taro","taro@yamada" }
            ,new string []{"Hanako","hanako@flower" }
            ,new string []{"Sachiko","sachiko@happy" }
        };

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Num { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //Message = "これは新たに設定されたメッセージです";
            Message = "入力してください";
        }
        public void OnPost(string name, string password, string mail, string tel)
        {
            Message = name + "," + password + "," + mail + "," + tel;
        }
        public string GetData(int id)
        {
            string[] target = data[id];
            return target[0] + "," + target[1];
        }

    }
}
