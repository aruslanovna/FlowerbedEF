using Domain;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Flower> Flowers { get; }

        IRepository<Plantation> Plantations { get; }

        IRepository<PlantationFlower> PlantationFlowers { get; }

        IRepository<Supply> Supplies { get; }

        IRepository<SupplyFlower> SupplyFlowers { get; }

        IRepository<Warehouse> Warehouses { get; }

        IRepository<WarehouseFlower> WarehouseFlowers { get; }

        Task SaveChangesAsync();
    }
}
