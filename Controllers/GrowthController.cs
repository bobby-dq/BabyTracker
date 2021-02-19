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
    public class GrowthController: Controller
    {
        private BabyTrackerContext context;
        public GrowthController(BabyTrackerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(long id)
        {
            ViewData["InfantName"] =  context.Infants.FirstOrDefault(i => i.InfantId == id).FirstName;
            ViewBag.Id = id;
            IEnumerable<Growth> Growths = context.Growths.Where(g => g.InfantId == id).Select(g => g);
            return View("Index", Growths);
        }

        public async Task<IActionResult> Details (long id)
        {
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            Infant infant = growth.Infant;
            GrowthViewModel model = GrowthViewModelFactory.Details(growth, infant);
            return View("GrowthEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            Growth growth = new Growth
            {
                Date = DateTime.Now,
                InfantId = id
            };
            return View ("GrowthEditor", GrowthViewModelFactory.Create(growth, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create(long id, [FromForm] Growth growth)
        {   
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (ModelState.IsValid)
            {
                growth.GrowthId = default;
                growth.Infant = default;
                context.Growths.Add(growth);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = growth.InfantId});
            }
            return View("GrowthEditor", GrowthViewModelFactory.Create(growth, infant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            return View("GrowthEditor", GrowthViewModelFactory.Edit(growth, growth.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Growth growth)
        {
            Growth preSaveGrowth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            Infant infant = preSaveGrowth.Infant;
            if (ModelState.IsValid)
            {
                growth.GrowthId = default;
                growth.Infant = default;
                context.Growths.Update(growth);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = growth.InfantId});
            }
            return View("GrowthEditor", GrowthViewModelFactory.Edit(growth, infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            return View("GrowthEditor", GrowthViewModelFactory.Delete(growth, growth.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Growth growth)
        {
            long infantId = growth.InfantId;
            context.Growths.Remove(growth);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}