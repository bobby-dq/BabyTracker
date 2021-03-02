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
    public class GrowthController: Controller
    {
        private BabyTrackerContext context;
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private bool IsGrowthOwner(Growth growth) => growth.Infant.UserId == userManager.GetUserId(User);

        public GrowthController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
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
            
            ViewData["InfantName"] = infant.FirstName;
            ViewBag.Id = id;
            IEnumerable<Growth> Growths = context.Growths.Where(g => g.InfantId == id).Select(g => g);
            return View("Index", Growths);
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            if (!IsGrowthOwner(growth))
            {
                return RedirectToPage("/Error/Error404");
            }

            Infant infant = growth.Infant;
            GrowthViewModel model = GrowthViewModelFactory.Details(growth, infant);
            return View("GrowthEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Infant preSaveInfant = context.Infants.AsNoTracking().FirstOrDefault(i => i.InfantId == id);

            if (!IsInfantOwner(preSaveInfant))
            {
                return RedirectToPage("/Error/Error404");
            } 

            if (ModelState.IsValid)
            {
                growth.GrowthId = default;
                growth.Infant = default;
                context.Growths.Add(growth);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = growth.InfantId});
            }
            return View("GrowthEditor", GrowthViewModelFactory.Create(growth, preSaveInfant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);

            if (!IsGrowthOwner(growth))
            {
                return RedirectToPage("/Error/Error404");
            }

            return View("GrowthEditor", GrowthViewModelFactory.Edit(growth, growth.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Growth growth)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            
            Growth preSaveGrowth = await context.Growths.AsNoTracking().Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            
            if (!IsGrowthOwner(preSaveGrowth))
            {
                return RedirectToPage("/Error/Error404");
            }

            Infant infant = preSaveGrowth.Infant;
            if (ModelState.IsValid)
            {
                context.Growths.Update(growth);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = growth.InfantId});
            }
            return View("GrowthEditor", GrowthViewModelFactory.Edit(growth, infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            if(!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Growth growth = await context.Growths.Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            if(!IsGrowthOwner(growth))
            {
                return RedirectToPage("/Error/Error404");
            }
            return View("GrowthEditor", GrowthViewModelFactory.Delete(growth, growth.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, Growth growth)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            
            Growth preSaveGrowth = await context.Growths.AsNoTracking().Include(g => g.Infant).FirstOrDefaultAsync(g => g.GrowthId == id);
            
            if (!IsGrowthOwner(preSaveGrowth))
            {
                return RedirectToPage("/Error/Error404");
            }

            long infantId = growth.InfantId;
            context.Growths.Remove(growth);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}