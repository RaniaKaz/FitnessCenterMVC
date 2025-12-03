namespace webProject.Models
{
    public class Salon
    {
        public int ID { get; set; }
        public string CalismaSaatleri { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<HizSalon> HizSalonlar { get; set; }
    }

}
