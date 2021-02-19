using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
     public class GrowthViewModelFactory
    {
        public static GrowthViewModel Details (Growth growth, Infant infant)
        {
            return new GrowthViewModel
            {
                Growth = growth,
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
                
            };
        }

        public static GrowthViewModel Create (Growth growth, Infant infant)
        {
            return new GrowthViewModel
            {
                Growth = growth,
                Infant = infant,
            };
        }

        public static GrowthViewModel Edit (Growth growth, Infant infant)
        {
            return new GrowthViewModel
            {
                Growth = growth,
                Infant = infant,
                Action = "Edit",
                Theme = "warning",
            };
        }

        public static GrowthViewModel Delete(Growth growth, Infant infant)
        {
            return new GrowthViewModel
            {
                Growth = growth,
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger",
                ShowAction = true
            };
        }
    }
}