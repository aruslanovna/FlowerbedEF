using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Supply
    {
        [Key]
        public int Id { get; set; }
       
        public int WarehouseId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Status { get; set; }
        public int PlantationId { get; set; }
        public Plantation Plantation { get; set; }
        
        public Warehouse Warehouse{ get; set; }
        public ICollection<SupplyFlower> SupplyFlowers { get; set; }
    }
}
