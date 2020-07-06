using AutoMapper;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Dto;

namespace MortgageHouse.Backend.RestApi.Mapper
{
    public class GatewayMapper : Profile
    {
        public GatewayMapper()
        {
            InitializeToDto();
            InitializeFromDto();
        }

        public void InitializeToDto()
        {
            this.CreateMap<Address, AddressDto>();
            this.CreateMap<Contact, ContactDto>();
            this.CreateMap<ContactAddress, ContactAddressDto>();
        }

        public void InitializeFromDto()
        {
            this.CreateMap<AddressDto, Address>();
            this.CreateMap<ContactDto, Contact>();
            this.CreateMap<ContactAddressDto, ContactAddress>();
        }
    }
}
