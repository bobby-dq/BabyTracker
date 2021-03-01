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
    public class FeedingController: Controller
    {
        private BabyTrackerContext context;
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private bool IsFeedingOwner(Feeding feeding) => feeding.Infant.UserId == userManager.GetUserId(User);
        public FeedingController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
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
            
            ViewData["InfantName"] = infant.FirstName;
            ViewBag.Id = id;
            IEnumerable<Feeding> Feedings = context.Feedings.Where(f => f.InfantId == id).Select(f => f);
            return View("Index", Feedings);            
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }

            Feeding feeding = await context.Feedings.Include(f => f.Infant).FirstOrDefaultAsync(f => f.FeedingId == id);
            
            if (!IsFeedingOwner(feeding))
            {
                return RedirectToPage("/Error/Unauthorized");
            }

            Infant infant = feeding.Infant;
            FeedingViewModel model = FeedingViewModelFactory.Details(feeding, infant);
            return View("FeedingEditor", model);
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
            Feeding feeding = new Feeding
            {
                StartTime= DateTime.Now,
                InfantId = id
            };
            return View ("FeedingEditor", FeedingViewModelFactory.Create(feeding, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Feeding feeding)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            if (!IsInfantOwner(feeding.Infant))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            if (ModelState.IsValid)
            {
                feeding.FeedingId = default;
                feeding.Infant = default;
                context.Feedings.Add(feeding);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = feeding.InfantId});
            }
            return View("FeedingEditor", FeedingViewModelFactory.Create(feeding, feeding.Infant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            Feeding feeding = await context.Feedings.Include(f => f.Infant).FirstOrDefaultAsync(f => f.FeedingId == id);
            if (!IsFeedingOwner(feeding))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
           
            return View("FeedingEditor", FeedingViewModelFactory.Edit(feeding, feeding.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Feeding feeding)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            if (!IsFeedingOwner(feeding))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            if (ModelState.IsValid)
            {
                context.Feedings.Update(feeding);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = feeding.InfantId});
            }
            return View("FeedingEditor", FeedingViewModelFactory.Edit(feeding, feeding.Infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {

            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            Feeding feeding = await context.Feedings.Include(f => f.Infant).FirstOrDefaultAsync(f => f.FeedingId == id);
            if (!IsFeedingOwner(feeding))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            return View("FeedingEditor", FeedingViewModelFactory.Delete(feeding, feeding.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Feeding feeding)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Error/Unauthenticated");
            }
            if (!IsFeedingOwner(feeding))
            {
                return RedirectToPage("/Error/Unauthorized");
            }
            long infantId = feeding.InfantId;
            context.Feedings.Remove(feeding);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}