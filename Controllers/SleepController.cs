using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private bool IsSleepOwner(Sleep sleep) => sleep.Infant.UserId == userManager.GetUserId(User);

        public SleepController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
        {
            context = ctx;
            userManager = usrMgr;
        }

        public IActionResult Index(long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);

            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }
            ViewData["InfantName"] =  infant.FirstName;
            ViewBag.Id = id;
            IEnumerable<Sleep> Sleeps = context.Sleeps.Where(m => m.InfantId == id).Select(m => m);
            return View("Index", Sleeps);
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Sleep sleep = await context.Sleeps.Include(s => s.Infant).FirstOrDefaultAsync(s => s.SleepId == id);
            if(!IsSleepOwner(sleep))
            {
                return RedirectToPage("/Error/Error404");
            }
            Infant infant = sleep.Infant;
            SleepViewModel model = SleepViewModelFactory.Details(sleep, infant);
            return View("SleepEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);

            if(!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant preSaveInfant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if(!IsInfantOwner(preSaveInfant))
            {
                return RedirectToPage("/Error/Error404");
            }
            if (ModelState.IsValid)
            {
                sleep.SleepId = default;
                sleep.Infant = default;
                context.Sleeps.Add(sleep);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = sleep.InfantId});
            }
            return View("SleepEditor", SleepViewModelFactory.Create(sleep, preSaveInfant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Sleep sleep = await context.Sleeps.Include(m => m.Infant).FirstOrDefaultAsync(s => s.SleepId == id);
            if (!IsSleepOwner(sleep))
            {
                return RedirectToPage("/Error/Error404");
            }
            return View("SleepEditor", SleepViewModelFactory.Edit(sleep, sleep.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Sleep sleep)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Sleep preSaveSleep = await context.Sleeps.AsNoTracking().Include(s => s.Infant).FirstOrDefaultAsync(s => s.SleepId == id);
            if (!IsSleepOwner(preSaveSleep))
            {
                return RedirectToPage("/Error/Error404");
            }
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Sleep sleep = await context.Sleeps.Include(s => s.Infant).FirstOrDefaultAsync(s => s.SleepId == id);
            if (!IsSleepOwner(sleep))
            {
                return RedirectToPage("/Error/Error404");
            }
            return View("SleepEditor", SleepViewModelFactory.Delete(sleep, sleep.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, Sleep sleep)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Sleep preSaveSleep = await context.Sleeps.AsNoTracking().Include(s => s.Infant).FirstOrDefaultAsync(s => s.SleepId == id);
            if (!IsSleepOwner(preSaveSleep))
            {
                return RedirectToPage("/Error/Error404");
            }

            long infantId = sleep.InfantId;
            context.Sleeps.Remove(sleep);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}