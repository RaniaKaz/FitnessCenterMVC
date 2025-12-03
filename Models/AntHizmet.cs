namespace webProject.Models
{
    public class AntHizmet
    {
        public int AntID { get; set; }
        public int HizID { get; set; }
        public Antrenor Antrenor { get; set; }
        public Hizmet Hizmet { get; set; }
    }

}
