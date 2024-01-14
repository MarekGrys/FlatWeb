using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using FlatWeb.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FlatWeb.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            var userId = _userService.CreateUser(dto);

            return Created($"api/users/{userId}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<CreateUserDto>> GetAll()
        {
            var usersDto = _userService.GetUsers();

            return Ok(usersDto);

        }

        [HttpGet("{id}")]
        public ActionResult<CreateUserDto> Get([FromRoute] int id)
        {
            try
            {
                var userDto = _userService.GetOneUser(id);
                return Ok(userDto);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute]int id,[FromBody] CreateUserDto dto)
        {
            try
            {
                _userService.UpdateUser(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
    }
}
