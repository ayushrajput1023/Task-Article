using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task.Models;
using Task.Repository;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IArticleUser _repository;
        private IConfiguration _config;

        public UsersController(IArticleUser repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                return await _repository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<Users> RegisterUser([FromBody] Users user)
        {
            try
            {
                if (_repository != null)
                {
                    return await _repository.AddUser(user);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Users> GetUserByUsernamePassword(string username, string password)
        {
            try
            {
                if (_repository != null)
                {
                    var z = await _repository.GetUserByUsernameAndPassword(username, password);
                    return z;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginView loginView)
        {
            IActionResult response = Unauthorized();
            var user = await GetUserByUsernamePassword(loginView.UserName, loginView.Password);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private object GenerateJSONWebToken(Users UserInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
          {
                new Claim(ClaimTypes.Role,UserInfo.RoleModel)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
