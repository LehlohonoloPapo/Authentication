using Auth.Models;
using Auth.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        // GET: api/<AuthController>

        public AuthController(AuthService authService)
        {
            this._authService= authService;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<AuthResponse?> PostAsync([FromBody] AuthRequest authRequest)
        {
            var result = await _authService.GetUserAsync(authRequest);
            return result;
        }


    }
}
