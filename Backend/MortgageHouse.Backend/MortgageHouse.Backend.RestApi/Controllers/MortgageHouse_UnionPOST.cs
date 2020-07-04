using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Services.Business;
using MortgageHouse.Backend.Extensions;
using Newtonsoft.Json;

using MortgageHouse.Backend.Extensions;
using System.IO;
using System.Text;
using MortgageHouse.Backend.Dto;
using MortgageHouse.Backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using MortgageHouse.Backend.Constants;

namespace MortgageHouse.Backend.RestApi.Controllers
{
    [Produces("plain/text")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    public class MortgageHouse_UnionPOST : ControllerBase
    {
        public MortgageHouse_UnionPOST(IMapper mapper, AddressService addressMngr)
        {
            _addressMngr = addressMngr;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly AddressService _addressMngr;

        [HttpPost]
        [Route("/seed_data")]
        public ActionResult<string> SeedNewAddressData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    AddressDto addressItem = null;
                    string address = reader.ReadToEndAsync().Result;
                    if (!string.IsNullOrWhiteSpace(address) && !address.Contains("null"))
                        addressItem = JsonConvert.DeserializeObject<AddressDto>(address);

                    _addressMngr.WriteAddressForSpecifiedItem(addressItem);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
                return "Could not find any addresses for this query";
            }

            return "Successful Seeding";
        }
    }
}
