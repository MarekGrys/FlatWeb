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
        void DeleteFlat(int id);
        List<FlatDto> GetAll();
        FlatDto GetOne(int id);
        void UpdateFlat(int id, UpdateFlat updateFlat);
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

        public void UpdateFlat(int id, UpdateFlat updateFlat)
        {
            var flat = _dbContext.Flats.Find(id);

            if(flat==null)
                throw new Exception();

            flat.SquareMetrage = updateFlat.SquareMetrage;
            flat.RoomQuantity = updateFlat.RoomQuantity;
            flat.FloorNumber = updateFlat.FloorNumber;
            flat.Price = updateFlat.Price;
            flat.Description = updateFlat.Description;

            _dbContext.SaveChanges();
        }

        public void DeleteFlat(int id)
        {
            var flat = _dbContext.Flats.FirstOrDefault(x => x.Id == id);
            var address = _dbContext.Addresses.FirstOrDefault(x => x.Id == flat.AddressID);
            
            if(flat==null || address==null)
                throw new Exception("Nie ma!");
            
            _dbContext.Remove(flat);
            _dbContext.Remove(address);
            _dbContext.SaveChanges();
        }
    }
}
