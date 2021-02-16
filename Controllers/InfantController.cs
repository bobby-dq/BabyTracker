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
    public class InfantController: Controller
    {
        private IBabyTrackerRepository context;
        public InfantController(IBabyTrackerRepository ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View(context.Infants);
        }
    }
}