using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Group1_2.Models
{
    public class TaskAddition
    { 
        [Key]
        [Required]

        public int TaskId { get; set; } 

        [Required]
        public string Task { get; set; }

        public string DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; } //foreign key relationship

        public bool Completed { get; set; }
   

    }
}
