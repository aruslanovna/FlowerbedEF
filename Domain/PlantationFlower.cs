using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain.Inherited;

namespace Domain
{
    public class PlantationFlower:AmountOfFlowers
    {
        [Key]
        public int Id { get; set; }
        
       
        public int PlantationId { get; set; }
        public Plantation plantation { get; set; }
        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
    }
}
