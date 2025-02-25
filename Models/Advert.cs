using System.ComponentModel.DataAnnotations;

namespace EmreProje.Models
{
    public class Advert
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string AdvertTitle { get; set; }

        [Required, MaxLength(100)]
        public string Explain { get; set; }
        [Required]
        public string location { get; set; }
        public string cost { get; set; }


        public AdvertDetails advertDetails { get; set; }
    }
}
