using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public static class DiaperViewModelFactory
    {
        public static DiaperViewModel Details (Diaper diaper, Infant infant)
        {
            return new DiaperViewModel
            {
                Diaper = diaper,
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                ShowAction = false
                
            };
        }

        public static DiaperViewModel Create (Diaper diaper, Infant infant)
        {
            return new DiaperViewModel
            {
                Diaper = diaper,
                Infant = infant,
            };
        }

        public static DiaperViewModel Edit (Diaper diaper, Infant infant)
        {
            return new DiaperViewModel
            {
                Diaper = diaper,
                Infant = infant,
                ActionTheme = "text-white bg-yellow-500 hover:bg-yellow-600",
                Action = "Edit"
            };
        }

        public static DiaperViewModel Delete(Diaper diaper, Infant infant)
        {
            return new DiaperViewModel
            {
                Diaper = diaper,
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                ActionTheme = "text-white bg-red-600 hover:bg-red-700",
                ShowAction = true
            };
        }
    }
}