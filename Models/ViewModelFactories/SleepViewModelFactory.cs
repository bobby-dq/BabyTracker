using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public class SleepViewModelFactory
    {
        public static SleepViewModel Details (Sleep sleep, Infant infant)
        {
            return new SleepViewModel
            {
                Sleep = sleep,
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
                
            };
        }

        public static SleepViewModel Create (Sleep sleep, Infant infant)
        {
            return new SleepViewModel
            {
                Sleep = sleep,
                Infant = infant,
            };
        }

        public static SleepViewModel Edit (Sleep sleep, Infant infant)
        {
            return new SleepViewModel
            {
                Sleep = sleep,
                Infant = infant,
                Action = "Edit",
                Theme = "warning",
            };
        }

        public static SleepViewModel Delete(Sleep sleep, Infant infant)
        {
            return new SleepViewModel
            {
                Sleep  = sleep,
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger",
                ShowAction = true
            };
        }
    }
}