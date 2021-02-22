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
    public class SleepController: Controller
    {
        private BabyTrackerContext context;
        public SleepController(BabyTrackerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(long id)
        {
            ViewData["InfantName"] =  context.Infants.FirstOrDefault(i => i.InfantId == id).FirstName;
            ViewBag.Id = id;
            IEnumerable<Sleep> Sleeps = context.Sleeps.Where(m => m.InfantId == id).Select(m => m);
            return View("Index", Sleeps);
        }

        public async Task<IActionResult> Details (long id)
        {
            Sleep sleep = await context.Sleeps.Include(m => m.Infant).FirstOrDefaultAsync(m => m.SleepId == id);
            Infant infant = sleep.Infant;
            SleepViewModel model = SleepViewModelFactory.Details(sleep, infant);
            return View("SleepEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            Sleep sleep = new Sleep
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                InfantId = id
            };
            return View ("SleepEditor", SleepViewModelFactory.Create(sleep, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create(long id, [FromForm] Sleep sleep)
        {
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (ModelState.IsValid)
            {
                sleep.SleepId = default;
                sleep.Infant = default;
                context.Sleeps.Add(sleep);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = sleep.InfantId});
            }
            return View("SleepEditor", SleepViewModelFactory.Create(sleep, infant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            Sleep sleep = await context.Sleeps.Include(m => m.Infant).FirstOrDefaultAsync(m => m.SleepId == id);
            return View("SleepEditor", SleepViewModelFactory.Edit(sleep, sleep.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Sleep sleep)
        {
            Sleep preSaveSleep = await context.Sleeps.AsNoTracking().Include(m => m.Infant).FirstOrDefaultAsync(m => m.SleepId == id);
            Infant infant = preSaveSleep.Infant;
            if (ModelState.IsValid)
            {
                context.Sleeps.Update(sleep);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = sleep.InfantId});
            }
            return View("SleepEditor", SleepViewModelFactory.Edit(sleep, infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            Sleep sleep = await context.Sleeps.Include(m => m.Infant).FirstOrDefaultAsync(m => m.SleepId == id);
            return View("SleepEditor", SleepViewModelFactory.Delete(sleep, sleep.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Sleep sleep)
        {
            long infantId = sleep.InfantId;
            context.Sleeps.Remove(sleep);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}