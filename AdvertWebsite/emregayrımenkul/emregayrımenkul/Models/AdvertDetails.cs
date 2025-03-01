using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace emregayrımenkul.Models
{

    public class AdvertDetails
    {
        [Key]
        public int Id { get; set; }
        
        public string? Property { get; set; } // Emlak Tipi - For Sale, For Rent, etc.

        public decimal? NetArea { get; set; } // m² (Net)

        public string? RoomCount { get; set; } // Example: 3+1

        public string? BuildingAge { get; set; } // 21-25 years, etc.

        public int? FloorNumber { get; set; } // Floor number

        public int? TotalFloors { get; set; } // Total number of floors in the building

        public string? heating { get; set; } // Central Heating (Natural Gas), etc.

        public int? BathroomCount { get; set; }

        public  string? Kitchen { get; set; } // Closed, Open

        public string? Balcony { get; set; } // Yes, No

        public string? Elevator { get; set; } // Yes, No

        public string? Parking { get; set; } // Yes, No




        //burada ilişkiyi halletemeye çalıştım


        [ForeignKey("AdvertId")]
        public int AdvertId { get; set; }

        public virtual Advert Advert { get; set; }

    }
}
