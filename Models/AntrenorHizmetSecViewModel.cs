namespace webProject.Models
{
    public class AntrenorHizmetSecViewModel
    {
        public int AntrenorID { get; set; }
        public string AntrenorAdSoyad { get; set; }
        public List <HizmetSecItem> Hizmetler { get; set; }
    }
}
