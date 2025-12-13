namespace webProject.Models
{
    public class Randevu
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public int AtrenorID { get; set; }
        public int HizmetID { get; set; }

        public Uye uye { get; set; }
        public Antrenor atrenor { get; set; }
        public Hizmet hizmet { get; set; }
        public Salon salon { get; set; }

        public decimal Ucret { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan BaslangicSaat { get; set; }
        public TimeSpan BitisSaat { get; set; }
        public int sureDk { get; set; }
    }
}
