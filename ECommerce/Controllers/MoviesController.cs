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
    public class MoviesController : Controller
    {
        //private readonly IgenericRepository<Movie> genericRepository;
        //private readonly IgenericRepository<Cinema> CinemaRepository;
        private readonly IUnitOfWork unitOfWork;


        //public MoviesController(IgenericRepository<Movie> genericRepository, IgenericRepository<Cinema> cinemaRepository, IgenericRepository<Producer> ProducerRepository)
        //{
        //    this.genericRepository = genericRepository;
        //     this.CinemaRepository = cinemaRepository;
        //    this.ProducerRepository = ProducerRepository;
        //}

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var includeRelated = new string[] { "Cinema", "Producer" };
            var movies = await unitOfWork.Movies.GetAllAsync(includeRelated);
            return View(movies);
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var include = new string[] { "Cinema", "Producer" };

            var movie = await unitOfWork.Movies.GetByIdAsyncWInclud(i=>i.Id==id,include);
            //var movie = await _context.Movies
            //    .Include(m => m.Cinema)
            //    .Include(m => m.Producer)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }


            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CinemaId"] = new SelectList(await unitOfWork.Cinemas.GetAllAsync(null), "Id", "Name");
            ViewData["ProducerId"] = new SelectList(await unitOfWork.Producers.GetAllAsync(null), "Id", "FullName");
            return View();
        }


        //// POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl,StartDate,EndDate,Price,MovieCategory,CinemaId,ProducerId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
               await unitOfWork.Movies.AddAsync(movie);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaId"] = new SelectList(await unitOfWork.Cinemas.GetAllAsync(null), "Id", "Name", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(await unitOfWork.Producers.GetAllAsync(null), "Id", "FullName", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await unitOfWork.Movies.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(await unitOfWork.Cinemas.GetAllAsync(null), "Id", "Name", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(await unitOfWork.Producers.GetAllAsync(null), "Id", "FullName", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,StartDate,EndDate,Price,MovieCategory,CinemaId,ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await unitOfWork.Movies.UpdateAsync(id, movie);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinemaId"] = new SelectList(await unitOfWork.Cinemas.GetAllAsync(null), "Id", "Name", movie.CinemaId);
            ViewData["ProducerId"] = new SelectList(await unitOfWork.Producers.GetAllAsync(null), "Id", "FullName", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var include = new string[] { "Cinema", "Producer" };

            var movie =await unitOfWork.Movies.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await unitOfWork.Movies.GetByIdAsync(id);
            if (movie != null)
            {
              await unitOfWork.Movies.DeleteByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MovieExists(int id)
        {
            return await unitOfWork.Movies.GetByIdAsync(id) != null;
        }
    }
}
