using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Sleep
    {
        public long SleepId {get; set;}



        [Required(ErrorMessage="Please enter a date and time.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0: HH:mm ddd, dd-MMM-yyyy}")]
        [Display(Name="Start Time")]
        public DateTime StartTime {get; set;}



        [Required(ErrorMessage="Please enter a date and time.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0: HH:mm ddd, dd-MMM-yyyy}")]
        [Display(Name="End Time")]
        public DateTime EndTime {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Description {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Comments {get; set;}




        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}
