using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebApplication3.Pages.Db
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly WebApplication3.Data.FizzBuzzContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(WebApplication3.Data.FizzBuzzContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<FizzBuzz> FizzBuzz { get;set; }
        public string userId;

        public void OnGet()
        {
            userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            FizzBuzz =_context.FizzBuzzes
                .OrderByDescending(f => f.Date).Take(20)
                .ToList();
        }
    }
}
