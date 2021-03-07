namespace BabyTracker.Models.ViewModels
{
    public class DiaperViewModel
    {
        public Diaper Diaper {get; set;}
        public Infant Infant {get; set;}
        public string Action {get; set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get; set;} = "indigo";
        public bool ShowAction {get; set;} = true;
        public string ActionTheme {get; set;} = "text-white bg-indigo-500 hover:bg-indigo-700";
        
    }
}