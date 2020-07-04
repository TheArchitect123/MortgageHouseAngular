﻿using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Services.Business;
using MortgageHouse.Backend.Extensions;
using Newtonsoft.Json;

namespace MortgageHouse.Backend.RestApi.Controllers
{
    [Produces("plain/text")]
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageHouse_ContactsGET : ControllerBase
    {
        public MortgageHouse_ContactsGET(IMapper mapper, ContactsService contactsMngr)
        {
            _contactsMngr = contactsMngr;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly ContactsService _contactsMngr;

        [HttpGet]
        [Route("/get_contacts")]
        public ActionResult<string> GetAllAddresses()
        {
            try
            {
                return JsonConvert.SerializeObject(_contactsMngr.GetAllContacts());
            }
            catch (Exception ex)
            {
                ex.HandleException();
                return "Could not find any contacts for this query";
            }
        }

        [HttpGet]
        [Route("/get_singlecontact")]
        public ActionResult<string> GetAllAddresses([FromQuery] string firstName)
        {
            try
            {
                return JsonConvert.SerializeObject(_contactsMngr.GetContactForSpecifiedName(firstName));
            }
            catch (Exception ex)
            {
                ex.HandleException();
                return $"Could not find a contact for the name {firstName}";
            }
        }
    }
}
