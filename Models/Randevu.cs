namespace webProject.Models
{
    public class Randevu
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public int AntrenorID { get; set; }
        public int HizmetID { get; set; }

        public Uye Uye { get; set; }
        public Antrenor Antrenor { get; set; }
        public Hizmet Hizmet { get; set; }

        public decimal Ucret { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public bool OnayDurumu { get; set; }

    }
}
