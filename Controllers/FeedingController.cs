using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BabyTracker.Models;

namespace BabyTracker.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FeedingController:Controller
    {
        private BabyTrackerContext context;
        public FeedingController(BabyTrackerContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index(long id)
        {
            return View(context.Feedings.Include(f => f.Infant).Where(f => f.InfantId == id).Select(f => f));
        }
    }
}
