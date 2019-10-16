using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDiszpecser.Models
{
    public enum Kategoria { B, C, D, E }
    public class Gepjarmu
    {
        [Key]
        public int GepjarmuID { get; set; }

        [Required]
        public string Tipus { get; set; }

        [Required]
        public string Rendszam { get; set; }

        [Required]
        public int FutottKm { get; set; }

        [Required]
        public int SzervizCiklus { get; set; }

        [Required]
        public DateTime UtolsoSzerviz { get; set; }

        [Required]
        public Kategoria? Kategoria { get; set; }

        public int TelephelyID { get; set; }

        [ForeignKey("TelephelyID")]
        public virtual Telephely Telephely { get; set; }

        public virtual ICollection<Fuvar> Fuvarok { get; set; }
    }
}
