
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class Medication
    {
        public long MedicationId {get; set;}
        public MedicationEnum MedicationType {get; set;}
        public DateTime Date {get; set;}
        public string Description {get; set;}
        public string Comments {get; set;}

        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}
