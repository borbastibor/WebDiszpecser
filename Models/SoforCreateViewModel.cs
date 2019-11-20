using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDiszpecser.Models
{
    public class SoforCreateViewModel
    {
        public int SoforID { get; set; }

        [RegularExpression(@"^[\p{L}']$", ErrorMessage = "A családnévben ne használjon számokat és speciális karaktereket!")]
        [Required(ErrorMessage = "Nincs megadva a családnév!")]
        [DisplayName("Családnév")]
        public string Csaladnev { get; set; }

        [RegularExpression(@"^[\p{L}']$", ErrorMessage = "A keresztnévben ne használjon számokat és speciális karaktereket!")]
        [Required(ErrorMessage = "Nincs megadva a keresztnév!")]
        [DisplayName("Keresztnév")]
        public string Keresztnev { get; set; }

        [Required(ErrorMessage = "Nincs megadva a születési idő!")]
        [DisplayName("Születési idő")]
        public string SzulIdo { get; set; }

        [RegularExpression(@"^(\d{4})([A-Z]{2})$", ErrorMessage = "A jogosítványszám formátuma rossz (1234AB)!")]
        [StringLength(6, ErrorMessage = "A jogosítvány száma nem lehet több 6 karakternél!")]
        [Required(ErrorMessage = "Nincs megadva a jogosítvány száma!")]
        [DisplayName("Jogosítvány száma")]
        public string JogositvanySzam { get; set; }

        [Required(ErrorMessage = "Nincs megadva a jogosítvány érvényessége!")]
        [DisplayName("Érvényessége")]
        public string Ervenyesseg { get; set; }

        [Required(ErrorMessage = "Nincs megadva a jogosítvány kategóriája!")]
        [DisplayName("Kategória")]
        public Kategoria Kategoria { get; set; }

    }
}
