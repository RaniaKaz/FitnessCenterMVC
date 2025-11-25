using System.ComponentModel.DataAnnotations;

namespace webProject.Models
{
    public class Uye
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [MinLength(2, ErrorMessage = "Ad en az 2 karakter olmalıdır.")]

        public string Ad { get; set; }

        [MinLength(2, ErrorMessage = "Soyad en az 2 karakter olmalıdır.")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]

        public string Soyad { get; set; }

        /*[Required(ErrorMessage = "Yaş alanı zorunludur.")]
        [Range(17,60, ErrorMessage = "Yaş 17 ile 60 arasında olmalıdır.")]

        public int Yas { get; set; }*/

        [Required(ErrorMessage = "Telefon Numarası alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

    }
}
