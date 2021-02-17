using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BabyTracker.Models
{
    public class Diaper
    {
        public long DiaperId {get; set;}
        


        [Required(ErrorMessage="Please select a diaper type.")]
        [Display(Name="Diaper Type")]
        
        public DiaperEnum DiaperType{get; set;}


        
        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Description {get; set;}
        


        [StringLength(64, ErrorMessage="The field {0} cannot exceed more than 64 characters.")]
        public string Comments {get; set;}


        
        [Required(ErrorMessage="Please enter a date and time.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:HH:mm ddd, dd-MMM-yyyy}")]
        public DateTime Time {get; set;}



        // Foreign key data
        public long InfantId {get; set;}
        public Infant Infant {get; set;}
    }
}