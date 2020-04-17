using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Flower
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Name is required ")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name length cannot exceed 30 and be not shorter than 3 symbols ")]
        public string Name { get; set; }
        public string FlowerFamily { get; set; }
        public ICollection<PlantationFlower> PlantationFlowers{ get; set; }
        public ICollection<SupplyFlower> SupplyFlowers { get; set; }
        public ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
    }
}
