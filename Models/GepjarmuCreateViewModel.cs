using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDiszpecser.Models
{
    public class GepjarmuCreateViewModel
    {
        public int GepjarmuID { get; set; }

        [Required(ErrorMessage = "Adja meg a típust!")]
        [DisplayName("Gépjármű típusa")]
        public string Tipus { get; set; }

        [RegularExpression(@"^([A-Z]{3})(\d{3})$")]
        [StringLength(6, ErrorMessage = "Nem lehet több 6 karakternél!")]
        [Required(ErrorMessage = "Adja meg a rendszámot!")]
        [DisplayName("Gépjármű rendszáma")]
        public string Rendszam { get; set; }

        //[Required(ErrorMessage = "Adj meg a futott km-t!")]
        [DisplayName("Futott km")]
        public int FutottKm { get; set; }

        //[Required(ErrorMessage = "Aja meg a szervízciklust!")]
        [DisplayName("Gépjármű szervízciklusa (km)")]
        public int SzervizCiklus { get; set; }

        [Required(ErrorMessage = "Adja meg az utolsó szervíz időpontját!")]
        [DisplayName("Utolsó szervíz")]
        public string UtolsoSzerviz { get; set; }

        [Required(ErrorMessage = "Adja meg a kategóriát!")]
        [DisplayName("Gépjármű kategóriája")]
        public Kategoria? Kategoria { get; set; }

        [Required(ErrorMessage = "Adja meg a telephelyet!")]
        [DisplayName("Telephely címe")]
        public string SelectedTelephelyCim { get; set; }

        public IEnumerable<SelectListItem> Telephelyek { get; set; }
    }
}
