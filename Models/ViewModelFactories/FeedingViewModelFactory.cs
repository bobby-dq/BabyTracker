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
                Theme = "info",
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
                Theme = "warning",
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
                Theme = "danger",
                ShowAction = true
            };
        }
    }
}