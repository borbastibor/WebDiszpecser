using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDiszpecser.Models
{
    public class Sofor
    {
        [Key]
        public int SoforID { get; set; }

        [Required]
        public string Csaladnev { get; set; }

        [Required]
        public string Keresztnev { get; set; }

        [Required]
        public DateTime SzulIdo { get; set; }

        [Required]
        public string JogositvanySzam { get; set; }

        [Required]
        public DateTime Ervenyesseg { get; set; }

        [Required]
        public Kategoria Kategoria { get; set; }

        public virtual ICollection<Fuvar> Fuvarok { get; set; }
    }
}
