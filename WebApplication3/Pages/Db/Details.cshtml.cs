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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Data.FizzBuzzContext _context;

        public DetailsModel(WebApplication3.Data.FizzBuzzContext context)
        {
            _context = context;
        }

        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzzes.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
