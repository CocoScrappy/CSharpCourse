using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05TodosEF
{


    public class Todo
    {
        public int Id { get; set; }

        [Required] // means non-null
        [RegularExpression(@"^[a-zA-Z0-9./,;-+)(*!\s]{1,100}$",
             ErrorMessage = "only letters, digits, space ./,;-+)(*! allowed up to 100 characters!")]
        public string Task { get; set; } // 1-100 characters, only letters, digits, space ./,;-+)(*! allowed
        
        [Required]
        public int Difficulty { get; set; } // 1-5 only front-end validation

        [Required]
        public DateTime DueDate { get; set; } // 1900-2099 year required, format in GUI is whatever the OS is configured to use

        [Required]
        public Status TaskStatus { get; set; }
        public enum Status { Pending, Done, Delegated }


    }

}
