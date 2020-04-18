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
    public class PlantationFlowersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
      
        public PlantationFlowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        public async Task<IActionResult> Index()
        {
            var plantationFlower = _unitOfWork.PlantationFlowers.GetWithInclude( p => p.Flower, p => p.plantation);
            
            return View(plantationFlower.ToList());
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plantationFlower = _unitOfWork.PlantationFlowers.GetAllLazyLoad(p => p.Id == id, p => p.Flower, p => p.plantation).AsNoTracking().First();
           
            if (plantationFlower == null)
            {
                return NotFound();
            }

            return View(plantationFlower);
        }

      
        public IActionResult Create()
        {
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name");
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlantationId,FlowerId,Amount")] PlantationFlower plantationFlower)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PlantationFlowers.Create(plantationFlower);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", plantationFlower.FlowerId);
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantationFlower = await _unitOfWork.PlantationFlowers.GetByID(id);
            if (plantationFlower == null)
            {
                return NotFound();
            }
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", plantationFlower.FlowerId);
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

           [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlantationId,FlowerId,Amount")] PlantationFlower plantationFlower)
        {
            if (id != plantationFlower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.PlantationFlowers.Update(plantationFlower);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantationFlowerExists(plantationFlower.Id))
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
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name", plantationFlower.FlowerId);
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantationFlower =  _unitOfWork.PlantationFlowers.GetAllLazyLoad(p => p.Id==id, p => p.Flower, p => p.plantation).AsNoTracking().First();
              if (plantationFlower == null)
            {
                return NotFound();
            }

            return View(plantationFlower);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantationFlower = await _unitOfWork.PlantationFlowers.GetByID(id);
            _unitOfWork.PlantationFlowers.Delete(plantationFlower);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantationFlowerExists(int id)
        {
            return _unitOfWork.PlantationFlowers.Exist(id);

        }
    }
}
