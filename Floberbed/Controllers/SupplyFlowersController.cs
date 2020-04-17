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
    public class SupplyFlowersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplyFlowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: SupplyFlowers
        public async Task<IActionResult> Index()
        {
            var flowerbedDbContext = _unitOfWork.SupplyFlowers.GetAll();
                //.Include(s => s.Flower).Include(s => s.Supply);
            return View( flowerbedDbContext.ToList());
        }

        // GET: SupplyFlowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyFlower = await _unitOfWork.SupplyFlowers.GetByID(id);
                //.Include(s => s.Flower)
                //.Include(s => s.Supply)
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (supplyFlower == null)
            {
                return NotFound();
            }

            return View(supplyFlower);
        }

        // GET: SupplyFlowers/Create
        public IActionResult Create()
        {
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name");
            ViewData["SupplyId"] = new SelectList(_unitOfWork.Supplies.GetAll(), "Id", "Id");
            return View();
        }

        // POST: SupplyFlowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FlowerId,SupplyId,Amount")] SupplyFlower supplyFlower)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.SupplyFlowers.Create(supplyFlower);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", supplyFlower.FlowerId);
            ViewData["SupplyId"] = new SelectList(_unitOfWork.Supplies.GetAll(), "Id", "Id", supplyFlower.SupplyId);
            return View(supplyFlower);
        }

        // GET: SupplyFlowers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyFlower = await _unitOfWork.SupplyFlowers.GetByID(id);
            if (supplyFlower == null)
            {
                return NotFound();
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", supplyFlower.FlowerId);
            ViewData["SupplyId"] = new SelectList(_unitOfWork.Supplies.GetAll(), "Id", "Id", supplyFlower.SupplyId);
            return View(supplyFlower);
        }

        // POST: SupplyFlowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FlowerId,SupplyId,Amount")] SupplyFlower supplyFlower)
        {
            if (id != supplyFlower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.SupplyFlowers.Update(supplyFlower);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyFlowerExists(supplyFlower.Id))
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
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", supplyFlower.FlowerId);
            ViewData["SupplyId"] = new SelectList(_unitOfWork.Supplies.GetAll(), "Id", "Id", supplyFlower.SupplyId);
            return View(supplyFlower);
        }

        // GET: SupplyFlowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyFlower = await _unitOfWork.SupplyFlowers.GetByID(id);
                //.Include(s => s.Flower)
                //.Include(s => s.Supply)
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (supplyFlower == null)
            {
                return NotFound();
            }

            return View(supplyFlower);
        }

        // POST: SupplyFlowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplyFlower = await _unitOfWork.SupplyFlowers.GetByID(id);
            _unitOfWork.SupplyFlowers.Delete(supplyFlower);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyFlowerExists(int id)
        {
            return _unitOfWork.SupplyFlowers.Exist(id);
        }
    }
}
