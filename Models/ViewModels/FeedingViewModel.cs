using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BabyTracker.Models;

namespace BabyTracker.Models.ViewModels
{
    public class FeedingViewModel
    {
        public Feeding Feeding {get; set;}
        public string Action {get; set;}
        public bool ReadOnly {get; set;}
        public string Theme {get; set;}
        public bool ShowAction {get; set;}
        public IEnumerable<Infant> Infants {get; set;} = Enumerable.Empty<Infant>();
    }
}