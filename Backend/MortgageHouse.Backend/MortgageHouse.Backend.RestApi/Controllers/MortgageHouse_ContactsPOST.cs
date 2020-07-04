using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.Services.Business;

namespace MortgageHouse.Backend.RestApi.Controllers
{
    [Produces("plain/text")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    public class MortgageHouse_ContactsPOST : ControllerBase
    {
        public MortgageHouse_ContactsPOST(IMapper mapper, ContactsService contactsMngr)
        {
            _contactsMngr = contactsMngr;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly ContactsService _contactsMngr;
    }
}
