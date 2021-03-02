using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyTracker.Models
{
    public class Infant
    {
        [Required]
        public string UserId {get; set;}

        public long InfantId { get; set; }



        [Required(ErrorMessage="Please enter a first name.")]
        [StringLength(32, ErrorMessage="The {0} field cannot exceed more than 32 characters.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }




        [StringLength(32, ErrorMessage="The {0} field cannot exceed more than 32 characters.")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }



        [Required(ErrorMessage="Please enter a date")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }



        // Foreign key data
        public IEnumerable<Feeding> Feedings {get;set;}
        public IEnumerable<Growth> Growths {get; set;}
        public IEnumerable<Medication> Medications {get; set;}
        public IEnumerable<Sleep> Sleeps {get; set;}
        public IEnumerable<Diaper> Diapers {get; set;}
    }
}
