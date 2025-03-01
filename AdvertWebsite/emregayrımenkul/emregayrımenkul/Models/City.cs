using System.ComponentModel.DataAnnotations;

namespace emregayrımenkul.Models
{
    public class City
    {

        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }

        public ICollection<District> Districts { get; set; } // district connection 

    }
}
