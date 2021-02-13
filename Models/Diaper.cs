using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BabyTracker.Models
{
    public class Diaper
    {
        public decimal DiaperId {get; set;}
        public DiaperEnum DiaperType{get; set;}
        public string Description {get; set;}
        public string Comments {get; set;}
        public DateTime Time {get; set;}

        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}