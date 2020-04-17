using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Inherited;

namespace Domain
{
    public class Warehouse:Place
    {
        [Key]
        public int Id { get; set; }
       
       

        public ICollection<Supply> Supplies { get; set; }
        public ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
    }
}
