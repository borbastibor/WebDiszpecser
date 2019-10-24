using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDiszpecser.Models
{
    public class FuvarCreateViewModel
    {
        public int FuvarID { get; set; }

        [Required]
        [DisplayName("Szállítási feladat")]
        public string Feladat { get; set; }

        [Required]
        [DisplayName("Fuvar ideje")]
        public string IndulasIdeje { get; set; }

        [Required]
        [DisplayName("Berakó címe")]
        public string BerakoCim { get; set; }

        [Required]
        [DisplayName("Kirakó címe")]
        public string KirakoCim { get; set; }

        [DisplayName("Gépjárművek")]
        public string SelectedGepjarmu { get; set; }

        public IEnumerable<SelectListItem> GepjarmuList { get; set; }

        [DisplayName("Sofőrök")]
        public string SelectedSofor { get; set; }

        public IEnumerable<SelectListItem> SoforList { get; set; }
    }
}
