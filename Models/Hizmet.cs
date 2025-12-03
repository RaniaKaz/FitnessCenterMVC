namespace webProject.Models
{
    public class Hizmet
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public int SureDaikia { get; set; }
        public decimal Fiyat { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<HizSalon> HizSalonlar { get; set; }
        public ICollection<AntHizmet> AtrHizmetler { get; set; }
    }
}
