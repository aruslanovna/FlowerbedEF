using System;
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
    public class WarehouseFlowersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseFlowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: WarehouseFlowers
        public async Task<IActionResult> Index()
        {
            var warehouseFlower = _unitOfWork.WarehouseFlowers.GetAll();
            //var flowerbedDbContext = _unitOfWork.WarehouseFlowers.Include(w => w.Flower).Include(w => w.Warehouse);
            return View(warehouseFlower.ToList());
        }

        // GET: WarehouseFlowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var warehouseFlower = _unitOfWork.WarehouseFlowers.GetAll();
            //var warehouseFlower = await _unitOfWork.WarehouseFlowers
            //    .Include(w => w.Flower)
            //    .Include(w => w.Warehouse)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseFlower == null)
            {
                return NotFound();
            }

            return View(warehouseFlower);
        }

        // GET: WarehouseFlowers/Create
        public IActionResult Create()
        {
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name");
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id");
            return View();
        }

        // POST: WarehouseFlowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FlowerId,WarehouseId,Amount")] WarehouseFlower warehouseFlower)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WarehouseFlowers.Create(warehouseFlower);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", warehouseFlower.FlowerId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", warehouseFlower.WarehouseId);
            return View(warehouseFlower);
        }

        // GET: WarehouseFlowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseFlower = await _unitOfWork.WarehouseFlowers.GetByID(id);
            if (warehouseFlower == null)
            {
                return NotFound();
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", warehouseFlower.FlowerId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", warehouseFlower.WarehouseId);
            return View(warehouseFlower);
        }

        // POST: WarehouseFlowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FlowerId,WarehouseId,Amount")] WarehouseFlower warehouseFlower)
        {
            if (id != warehouseFlower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.WarehouseFlowers.Update(warehouseFlower);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseFlowerExists(warehouseFlower.Id))
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
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", warehouseFlower.FlowerId);
            ViewData["WarehouseId"] = new SelectList(_unitOfWork.Warehouses.GetAll(), "Id", "Id", warehouseFlower.WarehouseId);
            return View(warehouseFlower);
        }

        // GET: WarehouseFlowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var warehouseFlower = await _unitOfWork.WarehouseFlowers.GetByID(id);
            //var warehouseFlower = await _unitOfWork.WarehouseFlowers
            //    .Include(w => w.Flower)
            //    .Include(w => w.Warehouse)
            //  .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseFlower == null)
            {
                return NotFound();
            }

            return View(warehouseFlower);
        }

        // POST: WarehouseFlowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warehouseFlower = await _unitOfWork.WarehouseFlowers.GetByID(id);
            _unitOfWork.WarehouseFlowers.Delete(warehouseFlower);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseFlowerExists(int id)
        {
            return _unitOfWork.WarehouseFlowers.Exist(id);
        }
    }
}
