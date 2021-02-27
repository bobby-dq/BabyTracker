using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Growth
    {
        public long GrowthId {get; set;}
        


        [Required(ErrorMessage="Please select a growth type")]
        [Display(Name="Growth Type")]
        public GrowthEnum GrowthType {get; set;}



        [Column(TypeName="decimal(8, 2)")] 
        [Required(ErrorMessage="Please enter an amount (centimeters for height, kilograms for weight)")]
        [Range(0, 999999, ErrorMessage="Please enter a positive number.")]
        [Display(Prompt="Enter amount in centimeters for height, kilograms for weight.")]
        public decimal Amount {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Description {get; set;}



        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Comments {get; set;}



        [Required(ErrorMessage="Please enter a date.")]
        [DataType(DataType.Date)]
        public DateTime Date {get; set;}



        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
        

        
        // Metadata
        public readonly DateTime DateCreated = DateTime.Now;
    }
}
