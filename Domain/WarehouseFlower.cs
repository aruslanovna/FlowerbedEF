using Domain.Inherited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class WarehouseFlower:AmountOfFlowers
    {
        [Key]
        public int Id { get; set; }
       
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
