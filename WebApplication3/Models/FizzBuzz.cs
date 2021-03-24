using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class FizzBuzz
    {
        [Display(Name = "Twoja ulubiona ulica")]
        [Range(1, 1000, ErrorMessage = "Liczba jest spoza przyjętego zakresu"), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }

}
