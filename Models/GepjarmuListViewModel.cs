using System.ComponentModel;

namespace WebDiszpecser.Models
{
    public class GepjarmuListViewModel
    {
        public int GepjarmuID { get; set; }

        [DisplayName("Típus")]
        public string Tipus { get; set; }

        [DisplayName("Rendszám")]
        public string Rendszam { get; set; }

        [DisplayName("Futott km")]
        public int FutottKm { get; set; }

        [DisplayName("Kategória")]
        public Kategoria? Kategoria { get; set; }

        [DisplayName("Telephely")]
        public string TelephelyCim { get; set; }
    }
}
