using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tema2PS.Models
{
    public class TicketModel
    {
        [Key]
        public int TicketModelId 
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Title")]
        public string title 
        { 
            get; 
            set; 
        }


        [Required]
        [Display(Name = "Row number")]
        public int row 
        { 
            get; 
            set; 
        }

        [Required]
        [Display(Name = "Place number")]
        public int place
        { 
            get; 
            set; 
        }
    }
}