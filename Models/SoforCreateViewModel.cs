using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDiszpecser.Models
{
    public class SoforCreateViewModel
    {
        public int SoforID { get; set; }

        [Required]
        [DisplayName("Családnév")]
        public string Csaladnev { get; set; }

        [Required]
        [DisplayName("Keresztnév")]
        public string Keresztnev { get; set; }

        [Required]
        [DisplayName("Születési idő")]
        public string SzulIdo { get; set; }

        [Required]
        [DisplayName("Jogosítvány száma")]
        public string JogositvanySzam { get; set; }

        [Required]
        [DisplayName("Érvényessége")]
        public string Ervenyesseg { get; set; }

        [Required]
        [DisplayName("Kategória")]
        public Kategoria Kategoria { get; set; }

    }
}
