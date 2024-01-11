using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Controllers
{
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {

        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressController(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Address>> GetAll()
        {
            var addresses = _dbContext.Addresses.ToList();


            //var flatsDto = _mapper.Map<List<FlatDto>>(flats);

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public ActionResult<Address> Get([FromRoute] int id)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.Id == id);

            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }
    }
}
