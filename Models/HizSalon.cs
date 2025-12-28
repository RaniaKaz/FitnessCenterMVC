namespace webProject.Models
{
    public class HizSalon
    {
        public int ID { get; set; }
        public int HizmetID { get; set; }
        public int SalonID { get; set; }

        public decimal Fiyat { get; set; }
        public int Sure { get; set; }

        public Hizmet Hizmet { get; set; }
        public Salon Salon { get; set; }
    }

}
