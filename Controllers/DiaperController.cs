using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private bool IsDiaperOwner(Diaper diaper) => diaper.Infant.UserId == userManager.GetUserId(User);
        public DiaperController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
        {
            context = ctx;
            userManager = usrMgr;
        }

        public IActionResult Index(long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

            ViewData["InfantName"] =  context.Infants.FirstOrDefault(i => i.InfantId == id).FirstName;
            ViewBag.Id = id;
            IEnumerable<Diaper> Diapers = context.Diapers.Where(d => d.InfantId == id).Select(d => d);
            return View("Index", Diapers);
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
    
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            
            Infant infant = diaper.Infant;
            DiaperViewModel model = DiaperViewModelFactory.Details(diaper, infant);
            return View("DiaperEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

            Diaper diaper = new Diaper
            {
                Time=DateTime.Now,
                InfantId = id
            };
            return View ("DiaperEditor", DiaperViewModelFactory.Create(diaper, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Diaper diaper)
        {

            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
    
            if (!IsInfantOwner(diaper.Infant))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
            
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

            return View("DiaperEditor", DiaperViewModelFactory.Edit(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Diaper diaper)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
    
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
            
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

            return View("DiaperEditor", DiaperViewModelFactory.Delete(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Diaper diaper)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
    
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            
            long infantId = diaper.InfantId;
            context.Diapers.Remove(diaper);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}