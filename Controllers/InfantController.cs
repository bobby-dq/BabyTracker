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
    public class InfantController: Controller
    {
        private BabyTrackerContext context;
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        public InfantController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
        {
            context = ctx;
            userManager = usrMgr;
        }
        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            IEnumerable<Infant> infants = context.Infants.OrderByDescending(i => i.Dob).Where(i => i.UserId == userManager.GetUserId(User));

            return View("Index", infants);
        }
        public async Task<IActionResult> Details (int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant i = await context.Infants.FirstOrDefaultAsync(i => i.InfantId == id);
            if (!IsInfantOwner(i))
            {
                return RedirectToPage("/Error/Error404");
            }
            InfantViewModel model = InfantViewModelFactory.Details(i);
            return View("InfantEditor", model);
        }

        // HTTP GET
        public IActionResult Create()
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Infant infant = new Infant
            {
                Dob = DateTime.Now,
                UserId = userManager.GetUserId(User)
            };

            return View("InfantEditor", InfantViewModelFactory.Create(infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Infant infant)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant infant = await context.Infants.FindAsync(id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }
            InfantViewModel model = InfantViewModelFactory.Edit(infant);
            return View("InfantEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (long id, [FromForm]Infant infant)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant preSaveInfant = await context.Infants.AsNoTracking().FirstOrDefaultAsync(i => i.InfantId == id);
            if (!IsInfantOwner(preSaveInfant))
            {
                return RedirectToPage("/Error/Error404");
            }
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
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant infant = await context.Infants.FindAsync(id);
            if (!IsInfantOwner(infant))
            {
                return RedirectToPage("/Error/Error404");
            }
            InfantViewModel model = InfantViewModelFactory.Delete(infant);
            return View("InfantEditor", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, Infant infant)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Infant preSaveInfant = await context.Infants.AsNoTracking().FirstOrDefaultAsync(i => i.InfantId == id);
            if (!IsInfantOwner(preSaveInfant))
            {
                return RedirectToPage("/Error/Error404");
            }
            context.Infants.Remove(infant);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}