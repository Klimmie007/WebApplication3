using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class FizzBuzz
    {
        private int number;
        [Display(Name = "Liczba z zakresu 1-1000")]
        [Range(1, 1000, ErrorMessage = "Liczba jest spoza przyjętego zakresu"), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                Result = "";
                if (value % 3 == 0)
                    Result += "Fizz";
                if (value % 5 == 0)
                    Result += "Buzz";
                else if (value % 3 != 0)
                {
                    Result = value.ToString();
                }
                number = value;
            }
        }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }

}
