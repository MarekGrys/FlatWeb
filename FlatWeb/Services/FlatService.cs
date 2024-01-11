using AutoMapper;
using FlatWeb.Entities;
using FlatWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FlatWeb.Services
{
    public interface IFlatService
    {
        int CreateFlat(FlatDto dto);
        List<FlatDto> GetAll();
        FlatDto GetOne(int id);
    }

    public class FlatService : IFlatService
    {

        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public FlatService(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private Flat myMap(FlatDto dto)
        {
            var result = new Flat()
            {
                Address = new Address()
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode,
                    StreetNumber = dto.StreetNumber,
                    FlatNumber = dto.FlatNumber

                },
                Description = dto.Description,
                FloorNumber = dto.FloorNumber,
                Price = dto.Price,
                RoomQuantity = dto.RoomQuantity,
                SquareMetrage = dto.SquareMetrage,
                WhenAdded = dto.WhenAdded,
                UserID = dto.UserID,


            };
            return result;
        }
        public List<FlatDto> GetAll()
        {
            var flats = _dbContext.Flats.Include(r => r.Address).ToList();
            
            var result = _mapper.Map<List<FlatDto>>(flats);

            return result;
        }

        public FlatDto GetOne(int id)
        {
            var flat = _dbContext.Flats.Include(r => r.Address).FirstOrDefault(x => x.Id == id);

            if (flat == null)
                throw new Exception("Nie ma");

            var result = _mapper.Map<FlatDto>(flat);

            return result;
        }

        public int CreateFlat(FlatDto dto)
        {
            if (!_dbContext.Users.Any(x => x.Id == dto.UserID))
                throw new Exception();

            var flat = myMap(dto);
            _dbContext.Flats.Add(flat);
            _dbContext.SaveChanges();

            return flat.Id;
        }
    }
}
