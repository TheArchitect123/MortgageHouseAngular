using MortgageHouse.Backend.Domain.Entities;

namespace MortgageHouse.Backend.Dto
{
    public class AddressDto
    {
        public string StreetNumber { get; set; }

        public string StreetName { get; set; }
        public StreetType StreetOption { get; set; }

        public string Suburb { get; set; }
        public int Postcode { get; set; }
    }
}
