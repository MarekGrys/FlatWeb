using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlatWeb.Services
{

    public interface IUserService
    {
        int CreateUser([FromBody] CreateUserDto dto);
        CreateUserDto GetOneUser(int id);
        List<CreateUserDto> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public int CreateUser([FromBody] CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }


        public List<CreateUserDto> GetUsers()
        {
            var users = _dbContext.Users.ToList();

            var result = _mapper.Map<List<CreateUserDto>>(users);

            return result;
        }


        public CreateUserDto GetOneUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new Exception("Nie ma");

            var result = _mapper.Map<CreateUserDto>(user);

            return result;
        }
    }
}
