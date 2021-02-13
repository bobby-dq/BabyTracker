using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class Sleep
    {
        public long SleepId {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public string Description {get; set;}
        public string Comment {get; set;}

        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}
