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
    public class MedicationController: Controller
    {
        private BabyTrackerContext context;
        public MedicationController(BabyTrackerContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(long id)
        {
            ViewData["InfantName"] =  context.Infants.FirstOrDefault(i => i.InfantId == id).FirstName;
            ViewBag.Id = id;
            IEnumerable<Medication> Medications = context.Medications.Where(m => m.InfantId == id).Select(m => m);
            return View("Index", Medications);
        }

        public async Task<IActionResult> Details (long id)
        {
            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            Infant infant = medication.Infant;
            MedicationViewModel model = MedicationViewModelFactory.Details(medication, infant);
            return View("MedicationEditor", model);
        }

        // HTTP Get
        public IActionResult Create (long id)
        {
            Infant infant = context.Infants.FirstOrDefault(i => i.InfantId == id);
            Medication medication = new Medication
            {
                Date = DateTime.Now,
                InfantId = id
            };
            return View ("MedicationEditor", MedicationViewModelFactory.Create(medication, infant));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Medication medication)
        {
            if (ModelState.IsValid)
            {
                medication.MedicationId = default;
                medication.Infant = default;
                context.Medications.Add(medication);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = medication.InfantId});
            }
            return View("MedicationEditor", MedicationViewModelFactory.Create(medication, medication.Infant));
        }

        // HTTP Get
        public async Task<IActionResult> Edit (long id)
        {
            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            return View("MedicationEditor", MedicationViewModelFactory.Edit(medication, medication.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Medication medication)
        {
            if (ModelState.IsValid)
            {
                context.Medications.Update(medication);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", new {id = medication.InfantId});
            }
            return View("MedicationEditor", MedicationViewModelFactory.Edit(medication, medication.Infant));
        }

        // HTTP GEt
        public async Task<IActionResult> Delete (long id)
        {
            Medication medication = await context.Medications.Include(m => m.Infant).FirstOrDefaultAsync(m => m.MedicationId == id);
            return View("MedicationEditor", MedicationViewModelFactory.Delete(medication, medication.Infant));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Medication medication)
        {
            long infantId = medication.InfantId;
            context.Medications.Remove(medication);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", new {id = infantId});
        }
    }
}