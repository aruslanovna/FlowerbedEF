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
    public class PlantationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlantationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Plantations
        public async Task<IActionResult> Index()
        {
            return View( _unitOfWork.Plantations.GetAll().ToList());
        }

        // GET: Plantations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantation = await _unitOfWork.Plantations.GetByID(id);
               
            if (plantation == null)
            {
                return NotFound();
            }

            return View(plantation);
        }

        // GET: Plantations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plantations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Plantations.Create(plantation);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plantation);
        }

        // GET: Plantations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantation = await _unitOfWork.Plantations.GetByID(id);
            if (plantation == null)
            {
                return NotFound();
            }
            return View(plantation);
        }

        // POST: Plantations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Plantation plantation)
        {
            if (id != plantation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Plantations.Update(plantation);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantationExists(plantation.Id))
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
            return View(plantation);
        }

        // GET: Plantations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantation = await _unitOfWork.Plantations.GetByID(id);
              
            if (plantation == null)
            {
                return NotFound();
            }

            return View(plantation);
        }

        // POST: Plantations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantation = await _unitOfWork.Plantations.GetByID(id);
            _unitOfWork.Plantations.Delete(plantation);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantationExists(int id)
        {
            return _unitOfWork.Plantations.Exist(id);
        }
    }
}
