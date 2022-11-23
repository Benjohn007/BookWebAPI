using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoBookAPI.Model.Models;
using Repository;
using System.Threading.Tasks;

namespace MyToDoBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccoutRepository _accoutRepository;

        public AccountController(IAccoutRepository accoutRepository)
        {
            _accoutRepository = accoutRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> AddSignUp([FromBody] SignUpModel signUpModel)
        {
            var result = await _accoutRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accoutRepository.LoginAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
