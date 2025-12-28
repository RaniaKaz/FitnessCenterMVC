using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace webProject.Models
{
    public class RandevuOlusturViewModel
    {
        [Required]
        public int SalonId { get; set; }

        [Required]
        public int HizmetId { get; set; }

        [Required]
        public int AntrenorId { get; set; }

        [Required]
        public DateTime BaslangicTarihi { get; set; }

        public List<SelectListItem> Salonlar { get; set; } = new();
    }

}
