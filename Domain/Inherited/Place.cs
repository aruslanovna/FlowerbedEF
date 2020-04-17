using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Inherited
{
    public class Place
    {

        [Required(ErrorMessage = "Name is required ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length cannot exceed 30 and be not shorter than 3 symbols ")]
        public string Name { get; }
        [Required]
        public string Address { get; }
    }
}
