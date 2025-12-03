namespace webProject.Models
{
    public class Antrenor
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string UzmanlıkAlanı { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<AntHizmet> Hizmetler { get; set; }
        public ICollection<AntMusaitlik> Musaitlikler { get; set; }
    }
}
