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
                Theme = "info",
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
                Action = "Edit",
                Theme = "warning",
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
                Theme = "danger",
                ShowAction = true
            };
        }
    }
}