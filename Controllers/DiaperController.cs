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
                return RedirectToPage("/Account/Login");
            }
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }

            ViewData["InfantName"] =  infant.FirstName;
            ViewBag.Id = id;
            IEnumerable<Diaper> Diapers = context.Diapers.Where(d => d.InfantId == id).Select(d => d);
            return View("Index", Diapers);
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
    
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Error404");
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
                return RedirectToPage("/Account/Login");
            }
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }

            Diaper diaper = new Diaper
            {
                Time=DateTime.Now,
                InfantId = id
            };
            return View ("DiaperEditor", DiaperViewModelFactory.Create(diaper, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create(long id, [FromForm] Diaper diaper)
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
                diaper.DiaperId = default;
                diaper.Infant = default;
                context.Diapers.Add(diaper);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Dashboard", new {id = diaper.InfantId});
            }
            return View("DiaperEditor", DiaperViewModelFactory.Create(diaper, preSaveInfant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
            
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Error404");
            }

            return View("DiaperEditor", DiaperViewModelFactory.Edit(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Diaper diaper)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Diaper preSaveDiaper = context.Diapers.AsNoTracking().Include(f => f.Infant).FirstOrDefault(d => d.DiaperId == id);

            if (!IsDiaperOwner(preSaveDiaper))
            {
                return RedirectToPage("/Error/Error404");
            }

            if (ModelState.IsValid)
            {
                context.Diapers.Update(diaper);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Dashboard", new {id = diaper.InfantId});
            }
            return View("DiaperEditor", DiaperViewModelFactory.Edit(diaper, preSaveDiaper.Infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Diaper diaper = await context.Diapers.Include(f => f.Infant).FirstOrDefaultAsync(f => f.DiaperId == id);
            
            if (!IsDiaperOwner(diaper))
            {
                return RedirectToPage("/Error/Error404");
            }

            return View("DiaperEditor", DiaperViewModelFactory.Delete(diaper, diaper.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, Diaper diaper)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Diaper preSaveDiaper = context.Diapers.AsNoTracking().Include(f => f.Infant).FirstOrDefault(d => d.DiaperId == id);
    
            if (!IsDiaperOwner(preSaveDiaper))
            {
                return RedirectToPage("/Error/Error404");
            }
            
            long infantId = diaper.InfantId;
            context.Diapers.Remove(diaper);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Dashboard", new {id = infantId});
        }
    }
}