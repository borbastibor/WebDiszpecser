using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDiszpecser.Models
{
    public class GepjarmuCreateViewModel
    {
        public int GepjarmuID { get; set; }

        [Required(ErrorMessage = "Nincs tÍpus megadva!")]
        [DisplayName("Gépjármű típusa")]
        public string Tipus { get; set; }

        [RegularExpression(@"^([A-Z]{3})(\d{3})$", ErrorMessage = "A rendszám formátuma rossz (ABC123)!")]
        [StringLength(6, ErrorMessage = "A rendszám nem lehet több 6 karakternél!")]
        [Required(ErrorMessage = "Nincs rendszám megadva!")]
        [DisplayName("Gépjármű rendszáma")]
        public string Rendszam { get; set; }

        [Required(ErrorMessage = "Nincs futott km megadva!")]
        [DisplayName("Futott km")]
        public int FutottKm { get; set; }

        [Required(ErrorMessage = "Nin szervízciklus megadva!")]
        [DisplayName("Gépjármű szervízciklusa (km)")]
        public int SzervizCiklus { get; set; }

        [Required(ErrorMessage = "Nincs megadva az utolsó szervíz időpontja!")]
        [DisplayName("Utolsó szervíz")]
        public string UtolsoSzerviz { get; set; }

        [Required(ErrorMessage = "Nincs megadva kategória!")]
        [DisplayName("Gépjármű kategóriája")]
        public Kategoria? Kategoria { get; set; }

        [Required(ErrorMessage = "Nincs megadva telephely!")]
        [DisplayName("Telephely címe")]
        public string SelectedTelephelyCim { get; set; }

        public IEnumerable<SelectListItem> Telephelyek { get; set; }
    }
}
