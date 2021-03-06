﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;

namespace Floberbed.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public async Task<IActionResult> Index()
        {
            var flowerbedDbContext =  _unitOfWork.Supplies.GetWithInclude(p => p.Warehouse);
           
            return View( flowerbedDbContext.ToList());
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = _unitOfWork.Supplies.GetAllLazyLoad(p => p.Id == id, p => p.Plantation, p => p.Warehouse).AsNoTracking().First();
           
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

     
        public IActionResult Create()
        {
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id");
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WarehouseId,ScheduledDate,ClosedDate,Status,PlantationId")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplies.Create(supply);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", supply.PlantationId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", supply.WarehouseId);
            return View(supply);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = await _unitOfWork.Supplies.GetByID(id);
            if (supply == null)
            {
                return NotFound();
            }
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", supply.PlantationId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", supply.WarehouseId);
            return View(supply);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WarehouseId,ScheduledDate,ClosedDate,Status,PlantationId")] Supply supply)
        {
            if (id != supply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Supplies.Update(supply);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyExists(supply.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", supply.PlantationId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", supply.WarehouseId);
            return View(supply);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supply = _unitOfWork.Supplies.GetAllLazyLoad(p => p.Id == id, p => p.Plantation, p => p.Warehouse).AsNoTracking().First();
          
            if (supply == null)
            {
                return NotFound();
            }

            return View(supply);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supply = await _unitOfWork.Supplies.GetByID(id);
            _unitOfWork.Supplies.Delete(supply);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyExists(int id)
        {
            return _unitOfWork.Supplies.Exist(id);
        }
    }
}
