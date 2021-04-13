using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApplication3.Data;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration _configuration { get; }
        private readonly FizzBuzzContext _context;
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

        public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
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
            _context.FizzBuzzes.Add(FizzBuzz);
            _context.SaveChanges();
            return Page();
        }
    }
}
