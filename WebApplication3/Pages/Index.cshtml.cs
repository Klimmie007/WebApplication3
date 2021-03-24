using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool Filled { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (SessionAddress != null)
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(SessionAddress);
        }
        public IActionResult OnPost()
        {   
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FizzBuzz.Result = "";
            if(FizzBuzz.Number % 3 == 0)
            {
                FizzBuzz.Result += "Fizz";
            }
            if(FizzBuzz.Number % 5 == 0)
            {
                FizzBuzz.Result += "Buzz";
            }
            if (FizzBuzz.Result == "")
            {
                FizzBuzz.Result = FizzBuzz.Number.ToString();
            }
            FizzBuzz.Date = DateTime.Now;
            HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
            return Page();
        }

    }
}
