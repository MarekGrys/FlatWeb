using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using FlatWeb.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Controllers
{
    [Route("api/flats")]
    public class FlatController : ControllerBase
    {

        private readonly IFlatService _flatService;
        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FlatDto>> GetAll()
        {
            var flatsDto = _flatService.GetAll();

            return Ok(flatsDto);

        }

        [HttpGet("{id}")]
        public ActionResult<Flat> Get([FromRoute]int id)
        {
            try
            {
                var flatDto = _flatService.GetOne(id);
                return Ok(flatDto);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }       
        }

        [HttpPost]
        public ActionResult CreateFlat([FromBody] FlatDto dto)
        {
            var newFlatID = _flatService.CreateFlat(dto);

            return Created($"api/flats/{newFlatID}", null);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFlat([FromRoute] int id, [FromBody] UpdateFlat flat) 
        {
            try
            {
                _flatService.UpdateFlat(id, flat);
                return Ok();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFlat([FromRoute] int id)
        {
            try
            {
                _flatService.DeleteFlat(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
