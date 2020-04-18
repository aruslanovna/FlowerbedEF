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
    public class FlowersController : Controller
    {
        private readonly  IUnitOfWork _unitOfWork;

        public FlowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<IActionResult> Index()
        {
            return View( _unitOfWork.Flowers.GetAll().ToList());
        }
           public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower =await  _unitOfWork.Flowers.GetByID(id);
               
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FlowerFamily")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Flowers.Create(flower);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower =await _unitOfWork.Flowers.GetByID(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FlowerFamily")] Flower flower)
        {
            if (id != flower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Flowers.Update(flower);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.Id))
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
            return View(flower);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower =await _unitOfWork.Flowers.GetByID(id);
               
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flower =await  _unitOfWork.Flowers.GetByID(id);
            _unitOfWork.Flowers.Delete(flower);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlowerExists(int id)
        {
            return _unitOfWork.Flowers.Exist(id);
        }
    }
}
