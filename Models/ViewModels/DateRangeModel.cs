using System.ComponentModel.DataAnnotations;
using System;


namespace BabyTracker.Models.ViewModels
{
    public class DateRangeModel
    {
        [DataType(DataType.Date)]
        [Display(Name="Start Date")]
        public DateTime StartDate {get; set;}

        [DataType(DataType.Date)]
        [Display(Name="End Date")]
        public DateTime EndDate {get; set;}

    }
}