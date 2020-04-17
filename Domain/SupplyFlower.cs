using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Inherited;

namespace Domain
{
    public class SupplyFlower:AmountOfFlowers
    {
        [Key]
        public int Id { get; set; }
        
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
    }
}
