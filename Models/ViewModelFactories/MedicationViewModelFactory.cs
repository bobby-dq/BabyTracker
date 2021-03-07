using BabyTracker.Models.ViewModels;

namespace BabyTracker.Models.ViewModelFactories
{
    public class MedicationViewModelFactory
    {
        public static MedicationViewModel Details (Medication medication, Infant infant)
        {
            return new MedicationViewModel
            {
                Medication = medication,
                Infant = infant,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
                
            };
        }

        public static MedicationViewModel Create (Medication medication, Infant infant)
        {
            return new MedicationViewModel
            {
                Medication = medication,
                Infant = infant,
            };
        }

        public static MedicationViewModel Edit (Medication medication, Infant infant)
        {
            return new MedicationViewModel
            {
                Medication = medication,
                Infant = infant,
                Action = "Edit",
                ActionTheme = "text-white bg-yellow-500 hover:bg-yellow-600"
            };
        }

        public static MedicationViewModel Delete(Medication medication, Infant infant)
        {
            return new MedicationViewModel
            {
                Medication = medication,
                Infant = infant,
                Action = "Delete",
                ReadOnly = true,
                ActionTheme = "text-white bg-red-600 hover:bg-red-700",
                ShowAction = true
            };
        }
    }
}