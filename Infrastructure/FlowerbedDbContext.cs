using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FlowerbedDbContext : DbContext
    {

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Plantation> Plantations { get; set; }
        public DbSet<PlantationFlower> PlantationFlowers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyFlower> SupplyFlowers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseFlower> WarehouseFlowers { get; set; }

        public FlowerbedDbContext(DbContextOptions<FlowerbedDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
