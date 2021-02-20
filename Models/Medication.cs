using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Medication
    {
        public long MedicationId {get; set;}



        [Required(ErrorMessage="Please select a feeding type.")]
        [Display(Name="Medication Type")]
        public MedicationEnum MedicationType {get; set;}



        [Required(ErrorMessage="Please enter a date and/or time.")]
        [DataType(DataType.DateTime)]
        [Display(Name="Date/Time")]
        public DateTime Date {get; set;}




        [Required(ErrorMessage="Please enter a description for the medication")]
        public string Description {get; set;}




        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Comments {get; set;}




        
        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}
