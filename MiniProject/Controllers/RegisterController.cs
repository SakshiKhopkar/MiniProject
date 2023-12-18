using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniProject.Model;
using MiniProject.Services;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http.Results;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService service;
        private readonly IConfiguration _config;
        
        public RegisterController(IRegisterService service, IConfiguration _config)
        {
            this.service = service;
            this._config = _config;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<Hashtable> Post(Register r)
        {
            Hashtable response = new Hashtable();
            try
            {
                Register list = await service.GetLogin(r);
                if (list != null)
                {
                    var token = GenerateToken(list);
                    response.Add("token",token);
                    response.Add("obj", list);
                    return response;
                    //return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    //return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return null;
        }

        [HttpPost]
        [Route("Registration")]

        public async Task<IActionResult> Post1([FromBody][Bind(include: "username,email,password")] Register user)
        {
            try
            {
                var result = await service.Registration(user);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private string GenerateToken(Register reg)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,reg.UserName),
                new Claim(ClaimTypes.Role,reg.Roleid.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

