using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace WebApplication3.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (SessionAddress != null)
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(SessionAddress);
        }
    }
}
