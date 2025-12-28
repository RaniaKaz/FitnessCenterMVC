using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webProject.Models
{
    public class Antrenor
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string UzmanlıkAlanı { get; set; }
        [ValidateNever]
        public ICollection<Randevu> Randevular{ get; set; }
        [ValidateNever]
        public ICollection<AntHizmet> AntHizmetler { get; set; }
        [ValidateNever]
        public ICollection<AntMusaitlik> Musaitlik { get; set; }
    }
}
