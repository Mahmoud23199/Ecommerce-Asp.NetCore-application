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
    public class CinemasController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CinemasController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            return View(await unitOfWork.Cinemas.GetAllAsync(null));
        }

        // GET: Cinemas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema = await unitOfWork.Cinemas.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Cinemas.AddAsync(cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Cinemas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema = await unitOfWork.Cinemas.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        // POST: Cinemas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (id != cinema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await unitOfWork.Cinemas.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        // GET: Cinemas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinema = await unitOfWork.Cinemas.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await unitOfWork.Cinemas.DeleteByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CinemaExists(int id)
        {
            return await unitOfWork.Cinemas.GetByIdAsync(id) != null;
        }
    }
}
