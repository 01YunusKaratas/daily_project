using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emregayrımenkul.Models
{
    public class Advert
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string AdvertTitle { get; set; } // ilan Başlıgı 

        [Required, MaxLength(500)] // Burayı değiştirmek lazım uzunluk olarka
        public string Explain { get; set; }// İlan açıklama

        [Required]
        public string UrlImage { get; set; } // resim zorunlu
        [Required] //Maliyet Zorunlu
        public int Cost { get; set; }


        //Burada diğer tablolarla baglantı sağlandı
        public AdvertDetails? AdvertDetails { get; set; }
        
        public int CityId { get; set; }
        public virtual City City { get; set; }
    
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}
