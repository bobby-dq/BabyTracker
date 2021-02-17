 using System;
using System.Collections.Generic;
using System.Linq;
using BabyTracker.Models;
using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public static class InfantViewModelFactory
    {
        public static InfantViewModel Details (Infant i)
        {
            return new InfantViewModel 
            {
                Infant = i,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
            };
        }

        public static InfantViewModel Create(Infant i)
        {
            return new InfantViewModel
            {
                Infant = i,
            };
        }
    }
}