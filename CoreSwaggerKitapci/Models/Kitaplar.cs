using System.ComponentModel.DataAnnotations;

namespace CoreSwaggerKitapci.Models
{
    public class Kitaplar
    {
        [Key]
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public string BasimTarihi { get; set; }
        public int Fiyat { get; set; }
        public int StokMiktari { get; set; }


    }
}
