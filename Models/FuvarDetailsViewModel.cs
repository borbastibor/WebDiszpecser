using System;
using System.ComponentModel;

namespace WebDiszpecser.Models
{
    public class FuvarDetailsViewModel
    {
        public int FuvarID { get; set; }

        [DisplayName("Szállítási feladat")]
        public string Feladat { get; set; }

        [DisplayName("Fuvar ideje")]
        public string IndulasIdeje { get; set; }

        [DisplayName("Berakás címe")]
        public string BerakoCim { get; set; }

        [DisplayName("Kirakás címe")]
        public string KirakoCim { get; set; }

        public int GepjarmuID { get; set; }

        [DisplayName("Gépjármű típusa és kategóriája")]
        public string GjmuTipus { get; set; }

        [DisplayName("Gépjármű rendszáma")]
        public string GjmuRendszam { get; set; }

        public int SoforID { get; set; }

        [DisplayName("Sofőr neve")]
        public string SoforNev { get; set; }

        [DisplayName("Jogosítvány száma")]
        public string JogositvanySzam { get; set; }

        [DisplayName("Jogosítvány érvényessége")]
        public string JogsiErvenyesseg { get; set; }

        [DisplayName("Jogosítvány kategóriája")]
        public string JogsiKategoria { get; set; }
    }
}
