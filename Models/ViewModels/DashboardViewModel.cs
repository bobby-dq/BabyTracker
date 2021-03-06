using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace BabyTracker.Models.ViewModels
{
    public class DashboardViewModel
    {
        public IdentityUser User {get; set;}
        public Infant Infant {get; set;}
        public IEnumerable<Diaper> Diapers {get;set;}
        public IEnumerable<Feeding> Feedings {get;set;}
        public IEnumerable<Growth> Growths {get;set;}
        public IEnumerable<Medication> Medications {get;set;}
        public IEnumerable<Sleep> Sleeps {get;set;}

    }
}