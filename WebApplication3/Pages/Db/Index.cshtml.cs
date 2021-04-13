using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Pages.Db
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.FizzBuzzContext _context;

        public IndexModel(WebApplication3.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }

        public async Task OnGetAsync()
        {
            FizzBuzz = await _context.FizzBuzzes
                .OrderByDescending(f => f.Date).Take(10)
                .ToListAsync();
        }
    }
}
