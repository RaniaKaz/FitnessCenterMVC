using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace webProject.Models
{
    public class Hizmet
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Hizmet adı gereklidir.")]
        [MinLength(2, ErrorMessage = "Hizmet adı en az 2 karakter olmalıdır.")]
        [Display(Name = "Hizmet Adı")]
        public string Ad { get; set; }
        [ValidateNever]
        public ICollection<Randevu> Randevular { get; set; }
        [ValidateNever]
        public ICollection<HizSalon> HizSalonlar { get; set; }
        [ValidateNever]
        public ICollection<AntHizmet> AtrHizmetler { get; set; }
    }
}
