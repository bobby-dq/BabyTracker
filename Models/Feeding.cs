using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class Feeding
    {
        public long FeedingId {get; set;}
        public FeedEnum FeedType {get; set;}
        public string Description {get; set;}
        public string Comments {get; set;}
        public DateTime StartTime{get; set;}
        public decimal Amount{ get; set;}
        public decimal Duration {get; set;}

        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}

    }
}
