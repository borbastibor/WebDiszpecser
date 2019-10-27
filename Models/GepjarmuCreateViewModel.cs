using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDiszpecser.Models
{
    public class GepjarmuCreateViewModel
    {
        public int GepjarmuID { get; set; }

        [Required]
        [DisplayName("Gépjármű típusa")]
        public string Tipus { get; set; }

        [Required]
        [DisplayName("Gépjármű rendszáma")]
        public string Rendszam { get; set; }

        [Required]
        [DisplayName("Futott km")]
        public int FutottKm { get; set; }

        [Required]
        [DisplayName("Gépjármű szervízciklusa")]
        public int SzervizCiklus { get; set; }

        [Required]
        [DisplayName("Utolsó szervíz")]
        public string UtolsoSzerviz { get; set; }

        [Required]
        [DisplayName("Gépjármű kategóriája")]
        public Kategoria? Kategoria { get; set; }

        [Required]
        [DisplayName("Telephely címe")]
        public string SelectedTelephelyCim { get; set; }

        public IEnumerable<SelectListItem> Telephelyek { get; set; }
    }
}
