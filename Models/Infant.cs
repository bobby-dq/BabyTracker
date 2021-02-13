using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Infant
    {
        public long InfantId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public IEnumerable<Feeding> Feedings {get;set;}
        public IEnumerable<Growth> Growths {get; set;}
        public IEnumerable<Medication> Medications {get; set;}
        public IEnumerable<Sleep> Sleeps {get; set;}
        public IEnumerable<Diaper> Diapers {get; set;}
    }
}
