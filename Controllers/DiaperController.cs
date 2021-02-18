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
    public class DiaperController: Controller
    {
        private BabyTrackerContext context;
        public DiaperController(BabyTrackerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(long id)
        {
            ViewData["InfantName"] =  context.Infants.FirstOrDefault(i => i.InfantId == id).FirstName;
            ViewBag.Id = id;
            IEnumerable<Diaper> Diapers = context.Diapers.Where(d => d.InfantId == id).Select(d => d);
            return View("Index", Diapers);
        }

        public async Task<IActionResult> Details (long id)
        {
            Diaper diaper = await context.Diapers.Include(d => d.Infant).FirstOrDefaultAsync(d => d.DiaperId == id);
            Infant infant = diaper.Infant;
            DiaperViewModel model = DiaperViewModelFactory.Details(diaper, infant);
            return View("DiaperEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            Diaper diaper = new Diaper
            {
                InfantId = id
            };
            return View ("DiaperEditor", DiaperViewModelFactory.Create(diaper, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Diaper diaper)
        {
            if (ModelState.IsValid)
            {
                diaper.DiaperId = default;
                diaper.Infant = default;
                context.Diapers.Add(diaper);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = diaper.InfantId});
            }
            return View("DiaperEditor", DiaperViewModelFactory.Create(diaper, diaper.Infant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            Diaper diaper = await context.Diapers.Include(d => d.Infant).FirstOrDefaultAsync(d => d.DiaperId == id);
            return View("DiaperEditor", DiaperViewModelFactory.Edit(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Diaper diaper)
        {
            if (ModelState.IsValid)
            {
                context.Diapers.Update(diaper);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = diaper.InfantId});
            }
            return View("DiaperEditor", DiaperViewModelFactory.Edit(diaper, diaper.Infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            Diaper diaper = await context.Diapers.Include(d => d.Infant).FirstOrDefaultAsync(d => d.DiaperId == id);
            return View("DiaperEditor", DiaperViewModelFactory.Delete(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Diaper diaper)
        {
            long infantId = diaper.InfantId;
            context.Diapers.Remove(diaper);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}