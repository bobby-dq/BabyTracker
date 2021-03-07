using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public class FeedingViewModelFactory
    {
        public static FeedingViewModel Details (Feeding feeding, Infant infant)
        {
            return new FeedingViewModel
            {
                Feeding = feeding,
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                ShowAction = false
                
            };
        }

        public static FeedingViewModel Create (Feeding feeding, Infant infant)
        {
            return new FeedingViewModel
            {
                Feeding = feeding,
                Infant = infant,
            };
        }

        public static FeedingViewModel Edit (Feeding feeding, Infant infant)
        {
            return new FeedingViewModel
            {
                Feeding = feeding,
                Infant = infant,
                Action = "Edit",
                ActionTheme = "text-white bg-yellow-500 hover:bg-yellow-600"
            };
        }

        public static FeedingViewModel Delete(Feeding feeding, Infant infant)
        {
            return new FeedingViewModel
            {
                Feeding = feeding,
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                ActionTheme = "text-white bg-red-600 hover:bg-red-700",
                ShowAction = true
            };
        }
    }
}