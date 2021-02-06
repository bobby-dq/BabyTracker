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
        public long InfantId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(Length:)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }

    }
}
