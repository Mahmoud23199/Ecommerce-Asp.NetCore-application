using ECommerce.Models;
using ECommerce.RepositoryServices;
using ECommerce.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ActorsController : Controller
    {
        private IUnitOfWork UnitOfWork;

        public ActorsController(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }


        public async Task<IActionResult> Index()
        {
            var data = await UnitOfWork.Actors.GetAllAsync(null);
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
               await UnitOfWork.Actors.AddAsync(actor);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(actor);
            }
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var actor = await UnitOfWork.Actors.GetByIdAsync(id);
            if(actor == null)
            {
                return View("Empty");
            }
            else
            {
                return View(actor);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View( await UnitOfWork.Actors.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,Actor actor)
        {
            if (ModelState.IsValid)
            {
                await UnitOfWork.Actors.UpdateAsync(id, actor);
                return RedirectToAction(nameof(Index));

            }
            else
            {
              return View(actor);
            }
        }
        public async Task<IActionResult> Delete(int id) 
        {
            return View(await UnitOfWork.Actors.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,IFormCollection formcollection)
        {
           await UnitOfWork.Actors.DeleteByIdAsync(id);
            return RedirectToAction(nameof (Index));
        }

    }
}
