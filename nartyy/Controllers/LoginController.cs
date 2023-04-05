using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nartyy.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace nartyy.Controllers
{

    [Route("Login")]
    public class LoginController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

      
        [Route("Loginnn")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Loginnn(string username, string password)
        {
            var userLogin = new UserLogin { Username=username,Password=password};
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);

                {
                    var zm = db.Narty.ToList();
                    var zm1 = db.ButyNarciarskiee.ToList();

                    ViewBag.Narty = zm;
                    ViewBag.Buty = zm1;
                    ViewBag.Token = token;
                    ViewData["Layout"] = "_Layout";
                    return View();
                }
            }
            else
            {
                return NotFound("user not found");
            }
        }

   

        // To generate token
        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Roles)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(x => x.Username.ToLower() ==
                userLogin.Username.ToLower() && x.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
