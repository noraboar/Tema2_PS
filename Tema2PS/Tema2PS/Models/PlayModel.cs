using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tema2PS.Models
{
    public class PlayModel
    {
        [Key]
        [Display(Name = "Title")]
        public string PlayModelId 
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Distribution")]
        public string distribution
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Directed by")]
        public string directedBy
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Premiere date"), DataType(DataType.Date)]
        public DateTime premiereDate 
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Ticket number")]
        public int TicketNumber 
        { 
            get; 
            set; 
        }
    }
}