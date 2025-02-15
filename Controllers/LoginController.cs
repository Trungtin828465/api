using DotnetAPIProject.Models.DTOs;
using DotnetAPIProject.Models.Entities;
using DotnetAPIProject.Services.Implementations;
using DotnetAPIProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _iLoginService;
        public LoginController(ILoginService iLoginService)
        {
            _iLoginService = iLoginService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetLogin()
        {
            var login = await _iLoginService.GetLoginAsync();
            return Ok(login);
        }

        //[HttpPost]
        //public async Task<ActionResult<Account>> CreateAccount(AccountDto accountDto)
        //{
        //    var account = await _iLoginService.CheckLoginAsync(accountDto);
        //    return CreatedAtAction(nameof(GetLogin), new { id = account.Id }, account);
        //}

        [HttpPost("login")]
        public async Task<IActionResult> CheckLogin([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _iLoginService.CheckLoginAsync(loginDto.UserName, loginDto.Password);

            if (account == null)
            {
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu!" });
            }

            return Ok(new { message = "Đăng nhập thành công", account });
        }

    }
}
