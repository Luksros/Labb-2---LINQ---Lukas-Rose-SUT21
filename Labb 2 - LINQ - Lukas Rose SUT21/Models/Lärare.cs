using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Models
{
    public class Lärare
    {
        public Lärare()
        {
            Ämnen = new List<Ämne>();
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string FNamn { get; set; }
        [Required]
        public string LNamn { get; set; }
        public List<Ämne> Ämnen { get; set; }
    }
}
