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
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0: HH:mm ddd, dd-MMM-yyyy}")]
        [Display(Name="Start Time")]
        public DateTime StartTime{get; set;}



        [Column(TypeName="decimal(8, 2)")] 
        [Required(ErrorMessage="Please enter an amount (grams for solid, and mililiters for fluids")]
        [Range(0, 999999, ErrorMessage="Please enter a positive number.")]
        [Display(Prompt="Enter amount in grams for solid, mililiters for fluids")]
        public decimal Amount{ get; set;}



        [Column(TypeName="decimal(8, 2)")] 
        [Required(ErrorMessage="Please enter duration (in minutes)")]
        [Range(0, 999999, ErrorMessage="Please enter a positive number.")]
        [Display(Prompt="Enter duration in minutes.")]
        public decimal Duration {get; set;}



        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}

    }
}
