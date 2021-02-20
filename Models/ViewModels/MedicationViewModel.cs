namespace BabyTracker.Models.ViewModels
{
    public class MedicationViewModel
    {
        public Medication Medication {get; set;}
        public Infant Infant {get; set;}
        public string Action {get; set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get; set;} = "primary";
        public bool ShowAction {get; set;} = true;
    
    }
}