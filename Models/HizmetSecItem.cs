using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace webProject.Models
{
    [NotMapped]
    public class HizmetSecItem
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public bool SeciliMi { get; set; }

    }
}


/*
 AntrenorHizmetSecViewModel
 ├── AntID
 ├── AntAdSoyad
 └── Hizmetler (List)
       ├── HizmetSecItem (Fitness)
       ├── HizmetSecItem (Yoga)
       └── HizmetSecItem (Pilates)
*/