using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Services.Business;

namespace MortgageHouse.Backend.RestApi.Controllers
{
    [Produces("plain/text")]
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageHouse_AddressPOST : ControllerBase
    {
        public MortgageHouse_AddressPOST(IMapper mapper, AddressService addressMngr)
        {
            _addressMngr = addressMngr;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly AddressService _addressMngr;
    }
}
