using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication3.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzzes { get; set; }
    }
}
