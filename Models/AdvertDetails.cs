using System.ComponentModel.DataAnnotations;

namespace EmreProje.Models
{
    public class AdvertDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PropertyType { get; set; } // Emlak Tipi - For Sale, For Rent, etc.

        [Required]
        public decimal? NetArea { get; set; } // m² (Net)

        public string RoomCount { get; set; } // Example: 3+1

        public string BuildingAge { get; set; } // 21-25 years, etc.

        public int FloorNumber { get; set; } // Floor number

        public int TotalFloors { get; set; } // Total number of floors in the building

        public string Heating { get; set; } // Central Heating (Natural Gas), etc.

        public int BathroomCount { get; set; }

        public string Kitchen { get; set; } // Closed, Open

        public bool Balcony { get; set; } // Yes, No

        public bool Elevator { get; set; } // Yes, No

        public bool Parking { get; set; } // Yes, No

        public bool Furnished { get; set; } // Yes, No

        public string UsageStatus { get; set; } // Vacant, Occupied

        public bool InSite { get; set; } // Yes, No

        public string SiteName { get; set; } // Unspecified, etc.

        public decimal? SiteFee { get; set; } // Site fee amount

        public bool SuitableForLoan { get; set; } // Yes, No

        public string TitleDeedStatus { get; set; } // Property deed status (e.g., Condominium)

        public string Seller { get; set; } // Real Estate Office, etc.

        public bool Exchange { get; set; } // Yes, No
    }
}