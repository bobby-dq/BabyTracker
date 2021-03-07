using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
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
    public class DashboardController: Controller
    {
        private BabyTrackerContext context;
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private DateTime endDate;
        private DateTime startDate;
        public DashboardController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
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
            IEnumerable<Diaper> diapers = context.Diapers.OrderByDescending(d => d.Time).Include(d => d.Infant).Where(d => d.InfantId == id);
            IEnumerable<Feeding> feedings = context.Feedings.OrderByDescending(f => f.StartTime).Include(f => f.Infant).Where(f => f.InfantId == id);
            IEnumerable<Growth> growths = context.Growths.OrderByDescending(g => g.Date).Include(g => g.Infant).Where(g => g.InfantId == id);
            IEnumerable<Medication> medications = context.Medications.OrderByDescending(m => m.Date).Include(m => m.Infant).Where(m => m.InfantId == id);
            IEnumerable<Sleep> sleeps = context.Sleeps.OrderByDescending(s => s.StartTime).Include(s => s.Infant).Where(s => s.InfantId == id);

            DashboardViewModel viewModel = new DashboardViewModel
            {
                Infant = infant,
                Diapers = diapers,
                Feedings = feedings,
                Growths = growths,
                Medications = medications,
                Sleeps = sleeps
            };

            return View("Index", viewModel);

        }

    }
}