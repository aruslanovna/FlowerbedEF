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
      public async Task<IActionResult> Index()
        {
            var flowerbedDbContext = _unitOfWork.SupplyFlowers.GetWithInclude(s => s.Supply);
                //.Include(s => s.Flower).Include(s => s.Supply);
            return View( flowerbedDbContext.ToList());
        }

          public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyFlower = _unitOfWork.SupplyFlowers.GetAllLazyLoad(p => p.Id == id, p => p.Flower, p => p.Supply).AsNoTracking().First();

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

          public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyFlower =  _unitOfWork.SupplyFlowers.GetAllLazyLoad(p => p.Id == id, p => p.Flower, p => p.Supply).AsNoTracking().First();
            
            if (supplyFlower == null)
            {
                return NotFound();
            }

            return View(supplyFlower);
        }

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
