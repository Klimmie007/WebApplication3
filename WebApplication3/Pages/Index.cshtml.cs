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
        [BindProperty]
        public string Message
        {
            get 
            {
                if (!ModelState.IsValid)
                {
                    return "";
                }
                string mess;
                var SessionAddress = HttpContext.Session.GetString("SessionAddress");
                if (SessionAddress != null)
                {
                    FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(SessionAddress);
                    if (FizzBuzz.Number % 3 == 0 || FizzBuzz.Number % 5 == 0)
                        mess = "Otrzymano: " + FizzBuzz.Result;
                    else
                        mess = "Liczba: " + FizzBuzz.Result + " nie spełnia kryteriów FizzBuzz";
                }
                else
                    mess = "";
                return mess;
            }
        }

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
        }
        public IActionResult OnPost()
        {   
            if (!ModelState.IsValid)
            {
                return Page();
            }
            FizzBuzz.Date = DateTime.Now;
            HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
            return Page();
        }
    }
}
