using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabyTracker.Models;
using BabyTracker.Models.ViewModels;
using BabyTracker.Models.RepositoryModels;
using BabyTracker.Models.ViewModelFactories;

namespace BabyTracker.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class InfantController: Controller
    {
        private BabyTrackerContext context;
        public InfantController(BabyTrackerContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Infants);
        }

        public async Task<IActionResult> Details (int id)
        {
            Infant i = await context.Infants.FirstOrDefaultAsync(i => i.InfantId == id);
            InfantViewModel model = InfantViewModelFactory.Details(i);
            return View("InfantEditor", model);
        }

        // HTTP GET
        public IActionResult Create()
        {
            return View("InfantEditor", InfantViewModelFactory.Create(new Infant{Dob=DateTime.Now}));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Infant infant)
        {
            if (ModelState.IsValid)
            {
                infant.InfantId = default;
                context.Infants.Add(infant);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("InfantEditor", InfantViewModelFactory.Create(infant));
        }

        // HTTP GET
        public async Task<IActionResult> Edit (long id)
        {
            Infant infant = await context.Infants.FindAsync(id);
            InfantViewModel model = InfantViewModelFactory.Edit(infant);
            return View("InfantEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit ([FromForm]Infant infant)
        {
            if (ModelState.IsValid)
            {
                context.Infants.Update(infant);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("InfantEditor", InfantViewModelFactory.Edit(infant));
        }

        // HTTP GET
        public async Task<IActionResult> Delete (long id)
        {
            Infant infant = await context.Infants.FindAsync(id);
            InfantViewModel model = InfantViewModelFactory.Delete(infant);
            return View("InfantEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Infant infant)
        {
            context.Infants.Remove(infant);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}