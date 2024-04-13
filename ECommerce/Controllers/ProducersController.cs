using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using ECommerce.RepositoryServices;
using ECommerce.UnitOfWork;

namespace ECommerce.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProducersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            var includeRelated = new string[] { };
            var result = await unitOfWork.Producers.GetAllAsync(includeRelated);
            return View(result);
        }


        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await unitOfWork.Producers.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,profilepictureURL,FullName,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                 await unitOfWork.Producers.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await unitOfWork.Producers.GetByIdAsync(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        // POST: Producers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,profilepictureURL,FullName,Bio")] Producer producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await unitOfWork.Producers.UpdateAsync(id, producer);
                
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producer = await unitOfWork.Producers.GetByIdAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await unitOfWork.Producers.GetByIdAsync(id);
            if (producer != null)
            {
              await unitOfWork.Producers.DeleteByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
       
        private async Task<bool> ProducerExists(int id)
        {
           return await unitOfWork.Producers.GetByIdAsync(id) != null;
        }

    } 
}
