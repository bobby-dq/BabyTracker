using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class Growth
    {
        public long GrowthId {get; set;}
        public GrowthEnum GrowthType {get; set;}
        public long Amount {get; set;}
        public string Description {get; set;}
        public string Comments {get; set;}
        public DateTime Date {get; set;}

        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}
