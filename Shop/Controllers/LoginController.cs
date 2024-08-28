using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Models;
using Shop.Repository.Class;
using Shop.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly EshopContext _context;
        private readonly IUserRepository _repo;

        public LoginController(IConfiguration config, EshopContext context, IUserRepository repo)
        {
            _config = config;
            _context = context;
            _repo = repo; 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ShopUser login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(ShopUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.UserRoll),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(720),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);           
        }

        private async Task<ShopUser?> AuthenticateUser(ShopUser login)
        {
            ShopUser user = null;

            var logUser = await _repo.GetShopUserByID(login.UserName, login.UserPassword);
            if (logUser != null) 
            {
                user = logUser;
            }
            return user;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetShopUsers());
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> Post(ShopUser sto)
        {
            var password = AesOperation.EncryptString(_config["Aes:Key"], sto.UserPassword);
            sto.UserPassword = password;
            var result = await _repo.InsertShopUser(sto);
            if (result.UserId == "")
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Put(ShopUser sto)
        {
            await _repo.UpdateShopUser(sto);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(string id)
        {
            bool result = await _repo.DeleteShopUser(id);
            return Ok("Deleted Successfully");
        }
    }
}
