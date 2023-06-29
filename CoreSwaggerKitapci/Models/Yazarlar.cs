using System.ComponentModel.DataAnnotations;

namespace CoreSwaggerKitapci.Models
{
    public class Yazarlar
    {
        [Key]
        public int YazarId { get; set; }
        public string YazarAdi { get; set; }
        public string YazarHakkinda { get; set; }

    }
}
