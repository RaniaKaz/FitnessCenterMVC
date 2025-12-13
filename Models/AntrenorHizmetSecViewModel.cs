namespace webProject.Models
{
    public class AntrenorHizmetSecViewModel
    {
        public int AntID { get; set; }
        public string AntAdSoyad { get; set; }
        public List <HizmetSecItem> Hizmetler { get; set; }
    }
}
