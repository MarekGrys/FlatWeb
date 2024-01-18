using AutoMapper;
using FlatWeb.Entities;

namespace FlatWeb.Services
{

    public interface IAccountService
    {

    }

    public class AccountService : IAccountService
    {
        private readonly FlatWebDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountService(FlatWebDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
