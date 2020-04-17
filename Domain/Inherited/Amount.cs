using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Inherited
{
   public class AmountOfFlowers
    {
        [Required]
        public int Amount { get; set; }
    }
}
