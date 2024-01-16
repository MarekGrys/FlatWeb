using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using FlatWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Controllers
{
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll()
        {
            var addresses = _addressService.GetAddresses();

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get([FromRoute] int id)
        {
            try
            {
                var address = _addressService.GetAddress(id);
                return Ok(address);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateAddress([FromRoute] int id, [FromBody] UpdateAddress address)
        {
            try
            {
                _addressService.UpdateAddress(id, address);
                return Ok();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
