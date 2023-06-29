using System.ComponentModel.DataAnnotations;

namespace CoreSwaggerKitapci.Models
{
    public class Turler
    {
        [Key]
        public int TurId { get; set; }
        public string TurAdi { get; set; }

    }
}
