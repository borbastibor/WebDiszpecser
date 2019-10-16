using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDiszpecser.Models
{
    public class Telephely
    {
        [Key]
        public int TelephelyID { get; set; }

        [Required]
        public string TelephelyCim { get; set; }

        public virtual ICollection<Gepjarmu> Gepjarmuvek { get; set; }
    }
}
