using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webProject.Models
{
    public class AntHizmet
    {
        public int ID { get; set; }
        public int AntrenorID { get; set; }
        public int HizmetID { get; set; }
        [ValidateNever]
        public Antrenor Antrenor { get; set; }
        [ValidateNever]
        public Hizmet Hizmet { get; set; }
    }

}
