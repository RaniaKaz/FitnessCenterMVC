namespace webProject.Models
{
    public class HizSalon
    {
        public int HizID { get; set; }
        public int SalID { get; set; }

        public decimal Fiyat { get; set; }
        public int Sure { get; set; }

        public Hizmet Hizmet { get; set; }
        public Salon Salon { get; set; }
    }

}
