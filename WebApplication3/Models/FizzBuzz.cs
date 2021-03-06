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
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Result { get; set; }
        [MaxLength(450)]
        public string UserId { get; set; }
    }

}
