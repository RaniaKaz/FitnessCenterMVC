namespace webProject.Models
{
    public class AntMusaitlik
    {
        public int ID { get; set; }
        public int AntID { get; set; }
        public DayOfWeek Gun { get; set; }
        //public TimeSpan BaslangicSaat { get; set; }
        //public TimeSpan BitisSaat { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public TimeSpan BitisAraligi { get; set; }
        public Antrenor Antrenor { get; set; }
    }

}
