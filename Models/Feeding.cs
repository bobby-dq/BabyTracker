using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Feeding
    {
        public long FeedingId {get; set;}



        [Required(ErrorMessage="Please select a feeding type.")]
        [Display(Name="Feeding Type")]
        public FeedEnum FeedType {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        [Display(Prompt="Enter feeding (eg. meal name) description here.")]
        public string Description {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Comments {get; set;}

    

        [Required(ErrorMessage="Please enter a date and time.")]
        [DataType(DataType.DateTime)]
        [Display(Name="Start Time")]
        public DateTime StartTime{get; set;}



        [Column(TypeName="decimal(8, 2)")]
        [Range(0, 999999, ErrorMessage="Please enter a positive number.")]
        [Display(Prompt="Enter amount in grams for solid, mililiters for fluids")]
        public decimal? Amount{ get; set;}



        [Column(TypeName="decimal(8, 2)")] 
        [Range(0, 999999, ErrorMessage="Please enter a positive number.")]
        [Display(Prompt="Enter duration in minutes (breastfeed).")]
        public decimal? Duration {get; set;}



        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}

    }
}
