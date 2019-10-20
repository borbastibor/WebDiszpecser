using System.ComponentModel;

namespace WebDiszpecser.Models
{
    public class FuvarListViewModel
    {
        public int FuvarID { get; set; }

        [DisplayName("Feladat")]
        public string Feladat { get; set; }

        [DisplayName("Fuvar ideje")]
        public string IndulasIdeje { get; set; }

        [DisplayName("Berakó címe")]
        public string BerakoCim { get; set; }

        [DisplayName("Kirakó címe")]
        public string KirakoCim { get; set; }

        [DisplayName("Gépjármű típusa")]
        public string GepjarmuTipus { get; set; }

        [DisplayName("Sofőr neve")]
        public string SoforNev { get; set; }
    }
}
