using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlatWeb.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Created($"api/users/{user.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CreateUserDto>> GetAll()
        {
            var users = _dbContext.Users.ToList();

            var usersDto = _mapper.Map<List<CreateUserDto>>(users);

            return Ok(usersDto);

        }

        [HttpGet("{id}")]
        public ActionResult<CreateUserDto> Get([FromRoute] int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();
            

            var userDto = _mapper.Map<CreateUserDto>(user);

            return Ok(userDto);
        }
    }
}
