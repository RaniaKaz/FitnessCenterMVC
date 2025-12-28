using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace webProject.Models
{
    public class AntMusaitlik
    {
        public int ID { get; set; }
        public int AntrenorID { get; set; }
        public DayOfWeek Gun { get; set; }
        public TimeSpan Baslangic { get; set; }
        public TimeSpan Bitis { get; set; }
        [ValidateNever]
        public Antrenor Antrenor { get; set; }
    }

}
