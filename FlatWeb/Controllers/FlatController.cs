using FlatWeb.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FlatWeb.Controllers
{
    [Route("api/flats")]
    public class FlatController : ControllerBase
    {
        private readonly FlatWebDbContext _dbContext;

        public FlatController(FlatWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flat>> GetAll()
        {
            var flats = _dbContext.Flats.ToList();

            return Ok(flats);

        }

        [HttpGet("{id}")]
        public ActionResult<Flat> Get([FromRoute]int id)
        {
            var flats = _dbContext.Flats.FirstOrDefault(x => x.Id == id);

            if(flats == null)
            {
                return NotFound();
            }

            return Ok(flats);
        }
    }
}
