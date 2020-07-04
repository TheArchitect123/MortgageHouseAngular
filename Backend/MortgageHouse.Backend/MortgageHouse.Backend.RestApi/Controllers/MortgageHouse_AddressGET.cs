using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.Extensions;
using MortgageHouse.Backend.Services.Business;
using Newtonsoft.Json;

namespace MortgageHouse.Backend.RestApi.Controllers
{
    [Produces("plain/text")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class MortgageHouse_AddressGET : ControllerBase
    {
        public MortgageHouse_AddressGET(IMapper mapper, AddressService addressMngr)
        {
            _addressMngr = addressMngr;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly AddressService _addressMngr;

        [HttpGet]
        [Route("/get_addresses")]
        public ActionResult<string> GetAllAddresses()
        {
            try
            {
                return JsonConvert.SerializeObject(_addressMngr.GetAllAddresses());
            }
            catch (Exception ex)
            {
                ex.HandleException();
                return "Could not find any addresses for this query";
            }
        }

        [HttpGet]
        [Route("/get_singleaddress")]
        public ActionResult<string> GetAllAddresses([FromQuery] string streetName)
        {
            try
            {
                return JsonConvert.SerializeObject(_addressMngr.GetAddressForSpecifiedName(streetName));
            }
            catch (Exception ex)
            {
                ex.HandleException();
                return $"Could not find an address for the name {streetName}";
            }
        }
    }
}
