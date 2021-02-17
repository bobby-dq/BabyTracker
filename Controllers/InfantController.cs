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
    public class InfantController: Controller
    {
        private BabyTrackerContext context;
        public InfantController(BabyTrackerContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Infants);
        }

        public async Task<IActionResult> Details (int id)
        {
            Infant i = await context.Infants.FirstOrDefaultAsync(i => i.InfantId == id);
            InfantViewModel model = InfantViewModelFactory.Details(i);
            return View("InfantEditor", model);
        }

        // HttpGet
        public IActionResult Create()
        {
            return View("InfantEditor", InfantViewModelFactory.Create(new Infant()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName", "LastName", "Dob")] Infant infant)
        {
            if (ModelState.IsValid)
            {
                infant.InfantId = default;
                context.Infants.Add(infant);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("InfantEditor", InfantViewModelFactory.Create(infant));
        }
    }
}