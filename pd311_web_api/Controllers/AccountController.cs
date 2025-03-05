using Microsoft.AspNetCore.Mvc;
using pd311_web_api.BLL.DTOs.Account;
using pd311_web_api.BLL.Services.Account;

namespace pd311_web_api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var result = await _accountService.LoginAsync(dto);

            if (result == null)
                return BadRequest("Incorrect userName or password");
            
            return Ok(result);
        }
    }
}
