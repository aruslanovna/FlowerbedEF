using Domain;

using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private FlowerbedDbContext _flowerbedDbContext;
        private IRepository<Flower> _flowers;

        private IRepository<Plantation> _plantations;

        private IRepository<PlantationFlower> _plantationFlowers;
        private IRepository<Supply> _supplies;
        private IRepository<SupplyFlower> _supplyFlowers;
        private IRepository<Warehouse> _warehouses;
        private IRepository<WarehouseFlower> _warehouseFlowers;

        public UnitOfWork(FlowerbedDbContext flowerbedDbContext)
        {
            _flowerbedDbContext = flowerbedDbContext;
        }

        public IRepository<Flower> Flowers
        {
            get
            {
                return _flowers ??
                   ( _flowers = new Repository<Flower>(_flowerbedDbContext));
            }
        }

        public IRepository<Plantation> Plantations
        {
            get
            {
                return _plantations ??
                    (_plantations = new Repository<Plantation>(_flowerbedDbContext));
            }
        }
        public IRepository<PlantationFlower> PlantationFlowers
        {
            get
            {
                return _plantationFlowers ??
                    (_plantationFlowers = new Repository<PlantationFlower>(_flowerbedDbContext));
            }
        }

        public IRepository<Supply> Supplies
        {
            get
            {
                return _supplies ??
                    (_supplies = new Repository<Supply>(_flowerbedDbContext));
            }
        }
        public IRepository<SupplyFlower> SupplyFlowers 
        {
            get
            {
                return _supplyFlowers ??
                    ( _supplyFlowers= new Repository<SupplyFlower>(_flowerbedDbContext));
            }
        }
public IRepository<Warehouse> Warehouses 
        {
            get
            {
                return _warehouses ??
                    (_warehouses = new Repository<Warehouse>(_flowerbedDbContext));
            }
        }
     public IRepository<WarehouseFlower>  WarehouseFlowers
        {
            get
            {
                return _warehouseFlowers ??
                    (_warehouseFlowers = new Repository<WarehouseFlower>(_flowerbedDbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await _flowerbedDbContext.SaveChangesAsync();
        }
    }
}
