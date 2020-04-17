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
       // private readonly FlowerbedDbContext _unitOfWork;
        public PlantationFlowersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: PlantationFlowers
        public async Task<IActionResult> Index()
        {
            var flowerbedDbContext = _unitOfWork.PlantationFlowers.GetAll();
            // var flowerbedDbContext = _unitOfWork.PlantationFlowers.Include(p => p.Flower).Include(p => p.plantation);
            return View( flowerbedDbContext.ToList());
        }

        // GET: PlantationFlowers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plantationFlower = await _unitOfWork.PlantationFlowers.GetByID(id);
            //var plantationFlower = await _unitOfWork.PlantationFlowers
            //    .Include(p => p.Flower)
            //    .Include(p => p.plantation)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (plantationFlower == null)
            {
                return NotFound();
            }

            return View(plantationFlower);
        }

        // GET: PlantationFlowers/Create
        public IActionResult Create()
        {
            ViewData["FlowerId"] = new SelectList(_unitOfWork.Flowers.GetAll(), "Id", "Name");
            ViewData["PlantationId"] = new SelectList(_unitOfWork.Plantations.GetAll(), "Id", "Id");
            return View();
        }

        // POST: PlantationFlowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: PlantationFlowers/Edit/5
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

        // POST: PlantationFlowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: PlantationFlowers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantationFlower = await _unitOfWork.PlantationFlowers.GetByID(id);
                //.Include(p => p.Flower)
                //.Include(p => p.plantation)
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (plantationFlower == null)
            {
                return NotFound();
            }

            return View(plantationFlower);
        }

        // POST: PlantationFlowers/Delete/5
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
