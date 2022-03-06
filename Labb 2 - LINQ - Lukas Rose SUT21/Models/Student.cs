using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public int KlassID { get; internal set; }
    }
}
