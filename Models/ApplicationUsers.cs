using Microsoft.AspNetCore.Identity;

namespace webProject.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public int? UyeID { get; set; }
        public Uye uye { get; set; }
    }
}
