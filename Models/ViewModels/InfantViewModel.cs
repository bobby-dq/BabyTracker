using System;
using System.Collections.Generic;
using System.Linq;

namespace BabyTracker.Models.ViewModels
{
    public class InfantViewModel
    {
        public Infant Infant {get; set;}
        public string Action {get;set;}
        public bool ReadOnly {get; set;}
        public string Theme {get;set;}
        public bool ShowAction {get; set;}
    }
}