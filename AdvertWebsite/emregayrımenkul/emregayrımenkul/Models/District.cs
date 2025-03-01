using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emregayrımenkul.Models
{
    public class District
    {
        public int Id { get; set; }
        [Required]
        public string DistrictName { get; set; }


        //Foreign Key connection
        
        [ForeignKey("CityId")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
