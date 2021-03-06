
namespace BabyTracker.Models.ViewModels
{
    public class GrowthViewModel
    {
        public Growth Growth {get;set;}
        public Infant Infant {get; set;}
        public string Action {get; set;} = "Create";
        public bool ReadOnly {get; set;} = false;
        public string Theme {get; set;} = "blue-500";
        public bool ShowAction {get; set;} = true;
        public string ActionTheme {get; set;} = "text-white bg-blue-400 hover:bg-blue-500";
    }
}