namespace webProject.Models
{
    public class AntMusaitlik
    {
        public int ID { get; set; }
        public int AntID { get; set; }
        public string Gun { get; set; }
        public TimeSpan BaslangicSaat { get; set; }
        public TimeSpan BitisSaat { get; set; }

        public Antrenor Antrenor { get; set; }
    }

}
