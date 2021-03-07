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
    public class MedicationController: Controller
    {
        private BabyTrackerContext context;
        private UserManager<IdentityUser> userManager;
        private bool IsLoggedIn() => User.Identity.IsAuthenticated;
        private bool IsInfantOwner(Infant infant) => infant.UserId == userManager.GetUserId(User);
        private bool IsMedicationOwner(Medication medication) => medication.Infant.UserId == userManager.GetUserId(User);
        public MedicationController(BabyTrackerContext ctx, UserManager<IdentityUser> usrMgr)
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
            IEnumerable<Medication> Medications = context.Medications.Where(m => m.InfantId == id).Select(m => m);
            return View("Index", Medications);
        }

        public async Task<IActionResult> Details (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);

            if (!IsMedicationOwner(medication))
            {
                return RedirectToPage("/Error/Error404");
            }

            Infant infant = medication.Infant;
            MedicationViewModel model = MedicationViewModelFactory.Details(medication, infant);
            return View("MedicationEditor", model);
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

            Medication medication = new Medication
            {
                Date = DateTime.Now,
                InfantId = id
            };
            return View ("MedicationEditor", MedicationViewModelFactory.Create(medication, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create(long id, [FromForm] Medication medication)
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
                medication.MedicationId = default;
                medication.Infant = default;
                context.Medications.Add(medication);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Dashboard", new {id = medication.InfantId});
            }
            return View("MedicationEditor", MedicationViewModelFactory.Create(medication, preSaveInfant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            if (!IsMedicationOwner(medication))
            {
                return RedirectToPage("/Error/Error404");
            }
            
            return View("MedicationEditor", MedicationViewModelFactory.Edit(medication, medication.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [FromForm] Medication medication)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }

            Medication preSaveMedication = await context.Medications.AsNoTracking().Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            
            if (!IsMedicationOwner(preSaveMedication))
            {
                return RedirectToPage("/Error/Error404");
            }
            
            Infant infant = preSaveMedication.Infant;
            if (ModelState.IsValid)
            {
                context.Medications.Update(medication);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Dashboard",new {id = medication.InfantId});
            }
            return View("MedicationEditor", MedicationViewModelFactory.Edit(medication, infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            if (!IsMedicationOwner(medication))
            {
                return RedirectToPage("/Error/Error404");
            }
            
            return View("MedicationEditor", MedicationViewModelFactory.Delete(medication, medication.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id, Medication medication)
        {
            if (!IsLoggedIn())
            {
                return RedirectToPage("/Account/Login");
            }
            Medication preSaveMedication = await context.Medications.AsNoTracking().Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            
            if (!IsMedicationOwner(preSaveMedication))
            {
                return RedirectToPage("/Error/Error404");
            }


            long infantId = medication.InfantId;
            context.Medications.Remove(medication);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Dashboard", new {id = infantId});
        }
    }
}