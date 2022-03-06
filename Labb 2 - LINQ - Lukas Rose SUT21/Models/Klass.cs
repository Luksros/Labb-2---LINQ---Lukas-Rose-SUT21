using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Models
{
    public class Klass
    {
        public Klass()
        {
            Elever = new List<Student>();
            Ämnen = new List<Ämne>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string KlassNamn { get; set; }
        public List<Student> Elever { get; set; }

        public List<Ämne> Ämnen { get; set; }
    }
}
