using FlatWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlatWeb.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
    }
}
