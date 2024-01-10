using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Controllers
{
    [Route("api/flats")]
    public class FlatController : ControllerBase
    {
        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlatController(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlatDto>> GetAll()
        {
            var flats = _dbContext.Flats.Include(r=>r.Address).ToList();


            var flatsDto = _mapper.Map<List<FlatDto>>(flats);

            return Ok(flatsDto);

        }

        [HttpGet("{id}")]
        public ActionResult<Flat> Get([FromRoute]int id)
        {
            var flat = _dbContext.Flats.Include(r => r.Address).FirstOrDefault(x => x.Id == id);

            if(flat == null)
            {
                return NotFound();
            }

            var flatDto = _mapper.Map<FlatDto>(flat);

            return Ok(flatDto);
        }
    }
}
