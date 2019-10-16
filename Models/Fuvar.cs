using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDiszpecser.Models
{
    public class Fuvar
    {
        [Key]
        public int FuvarID { get; set; }

        [Required]
        public string Feladat { get; set; }

        [Required]
        public DateTime IndulasIdeje { get; set; }

        [Required]
        public string BerakoCim { get; set; }

        [Required]
        public string KirakoCim { get; set; }

        public int GepjarmuID { get; set; }

        [ForeignKey("GepjarmuID")]
        public virtual Gepjarmu Gepjarmu { get; set; }

        public int SoforID { get; set; }

        [ForeignKey("SoforID")]
        public virtual Sofor Sofor { get; set; }
    }
}
