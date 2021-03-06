using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebApplication3.Pages.Db
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.FizzBuzzContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteModel(WebApplication3.Data.FizzBuzzContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            FizzBuzz = await _context.FizzBuzzes.FirstOrDefaultAsync(m => m.Id == id);
            if (FizzBuzz == null)
            {
                return NotFound();
            }
            if (FizzBuzz.UserId == null || UserId == null || FizzBuzz.UserId != UserId)
                return Redirect("./Details?id=" + id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzzes.FindAsync(id);
            if (FizzBuzz != null)
            {
                _context.FizzBuzzes.Remove(FizzBuzz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
