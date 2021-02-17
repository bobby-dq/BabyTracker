using System;
using System.Collections.Generic;
using System.Linq;

namespace BabyTracker.Models.ViewModels
{
    public class InfantViewModel
    {
        public Infant Infant {get; set;}
        public string Action {get;set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get;set;} = "primary";
        public bool ShowAction {get; set;} = true;
    }
}