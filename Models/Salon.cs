using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProject.Models
{
    public class Salon
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "Salon adı gereklidir.")]
        [Display(Name = "Salon Adı")]
        public string Ad { get; set; }

        [Column(TypeName = "time")]
        [Required (ErrorMessage = "Açılış Saati gereklidir.")]
        [Display(Name = "Açılış Saati")]
        public TimeOnly AcilisSaati { get; set; }

        [Column(TypeName = "time")]
        [Required (ErrorMessage = "Kapanış Saati gereklidir.")]
        [Display(Name = "Kapanış Saati")]
        public TimeOnly KapanisSaati { get; set; }

        [ValidateNever]
        public ICollection<Antrenor> Antrenor { get; set; }
        [ValidateNever]
        public ICollection<HizSalon> HizSalonlar { get; set; }
    }

}
