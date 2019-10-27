using System.ComponentModel;

namespace WebDiszpecser.Models
{
    public class GepjarmuDetailsViewModel
    {
        public int GepjarmuID { get; set; }

        [DisplayName("Gépjármű típusa")]
        public string Tipus { get; set; }

        [DisplayName("Gépjármű rendszáma")]
        public string Rendszam { get; set; }

        [DisplayName("Futott km")]
        public int FutottKm { get; set; }

        [DisplayName("Gépjármű szervízciklusa")]
        public int SzervizCiklus { get; set; }

        [DisplayName("Utolsó szervíz")]
        public string UtolsoSzerviz { get; set; }

        [DisplayName("Gépjármű kategóriája")]
        public Kategoria? Kategoria { get; set; }

        [DisplayName("Telephely címe")]
        public string TelephelyCim { get; set; }
    }
}
