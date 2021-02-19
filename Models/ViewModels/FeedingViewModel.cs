using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BabyTracker.Models;

namespace BabyTracker.Models.ViewModels
{
    public class FeedingViewModel
    {
        public Feeding Feeding {get; set;}
        public Infant Infant {get; set;}
        public string Action {get; set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get; set;} = "primary";
        public bool ShowAction {get; set;} = true;
    
    }
}