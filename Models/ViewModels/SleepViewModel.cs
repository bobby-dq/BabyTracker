namespace BabyTracker.Models.ViewModels
{
    public class SleepViewModel
    {
        public Sleep Sleep {get; set;}
        public Infant Infant {get; set;}
        public string Action {get; set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get; set;} = "purple";
        public bool ShowAction {get; set;} = true;
        public string ActionTheme {get; set;} = "text-white bg-purple-500 hover:bg-purple-700";
    }
}