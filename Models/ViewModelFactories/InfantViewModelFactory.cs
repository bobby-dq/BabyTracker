 using System;
using System.Collections.Generic;
using System.Linq;
using BabyTracker.Models;
using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public static class InfantViewModelFactory
    {
        public static InfantViewModel Details (Infant infant)
        {
            return new InfantViewModel 
            {
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
            };
        }

        public static InfantViewModel Create(Infant infant)
        {
            return new InfantViewModel
            {
                Infant = infant,
            };
        }

        public static InfantViewModel Edit (Infant infant)
        {
            return new InfantViewModel 
            {
                Infant = infant,
                Action = "Edit",
                Theme = "warning",
            };
        }

        public static InfantViewModel Delete(Infant infant)
        {
            return new InfantViewModel
            {
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger",
            };
        }
    }
}