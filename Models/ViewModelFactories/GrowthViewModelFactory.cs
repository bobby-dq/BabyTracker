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
                ActionTheme = "text-white bg-yellow-500 hover:bg-yellow-600",
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
                ActionTheme = "text-white bg-red-600 hover:bg-red-700",
                ShowAction = true
            };
        }
    }
}