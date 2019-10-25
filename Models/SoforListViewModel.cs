using System.ComponentModel;

namespace WebDiszpecser.Models
{
    public class SoforListViewModel
    {
        public int SoforID { get; set; }

        [DisplayName("Családnév")]
        public string Csaladnev { get; set; }

        [DisplayName("Keresztnév")]
        public string Keresztnev { get; set; }

        [DisplayName("Születési idő")]
        public string SzulIdo { get; set; }

        [DisplayName("Jogosítvány száma")]
        public string JogositvanySzam { get; set; }

        [DisplayName("Érvényessége")]
        public string Ervenyesseg { get; set; }

        [DisplayName("Kategória")]
        public Kategoria Kategoria { get; set; }
    }
}
