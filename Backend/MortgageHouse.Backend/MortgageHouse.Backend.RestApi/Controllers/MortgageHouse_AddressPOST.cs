using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MortgageHouse.Backend.Services.Business;
using Newtonsoft.Json;

using MortgageHouse.Backend.Extensions;

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


        [HttpGet]
        public ActionResult<string> Get_Comment(Guid id, Guid parent)
        {
            try
            {

                return JsonConvert.SerializeObject(_commentMngr.GetCommentById(id, parent));
            }
            catch (Exception ex)
            {
                ex.HandleException(_mapper, _repository, Guid.Empty, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }
    }
}
