using AutoMapper;
using FlatWeb.Entities;

namespace FlatWeb.Services
{
    public interface IAddressService
    {
        Address GetAddress(int id);
        List<Address> GetAddresses();
    }

    public class AddressService : IAddressService
    {

        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressService(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Address> GetAddresses()
        {
            var addresses = _dbContext.Addresses.ToList();

            return addresses;
        }

        public Address GetAddress(int id)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.Id == id);

            if(address == null)
            {
                throw new Exception("Nie ma!");
            }

            return address;
        }
    }
}
