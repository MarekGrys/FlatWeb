using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FlatWeb.Services
{

    public interface IUserService
    {
        void AddToFavourites(int userID, int flatID);
        int CreateUser([FromBody] CreateUserDto dto);
        void DeleteUser(int id);
        CreateUserDto GetOneUser(int id);
        List<CreateUserDto> GetUsers();
        void UpdateUser(int id, CreateUserDto updateUser);
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

        public void UpdateUser(int id, CreateUserDto updateUser)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
                throw new Exception("Nie ma!");

            user.Login = updateUser.Login;
            user.Password = updateUser.Password;
            user.Name = updateUser.Name;
            user.Surname = updateUser.Surname;
            user.PhoneNumber = updateUser.PhoneNumber;
            user.Email = updateUser.Email;

            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
                throw new Exception("Nie ma!");

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void AddToFavourites(int userID, int flatID)
        {
            var user = _dbContext.Users.FirstOrDefault(x=>x.Id == userID);
            if (user == null)
                throw new Exception("Brak!");


            var favouritesList = new List<string>();
            if(!user.Favourites.IsNullOrEmpty())
                favouritesList = user.Favourites.Split(',').ToList();
            
            if (favouritesList.Any(x => x == flatID.ToString()))
                throw new Exception("Już jest w ulubionych!");

            user.Favourites += $"{flatID},";
            _dbContext.SaveChanges();
        }
    }
}
