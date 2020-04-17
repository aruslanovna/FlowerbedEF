using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Inherited;

namespace Domain
{
    public class Plantation: Place
    {
        [Key]
        public int Id { get; set; }
     
        public ICollection<PlantationFlower> PlantationFlowers { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }
}
