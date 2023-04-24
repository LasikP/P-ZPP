using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using nartyy.Migrations;
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
                    var zm2 = db.Clients.ToList();
                    var zm3 = db.Rezerwacje.ToList();
                    ViewBag.Narty = zm;
                    ViewBag.Buty = zm1;
                    ViewBag.Client = zm2;
                    ViewBag.Rezerw = zm3;
                    ViewBag.Token = token;
                    ViewBag.User = username;
                    ViewData["Layout"] = "_Layout";
                    var usserr = db.Clients.FirstOrDefault(e => e.Username == username);


                    var lista = db.Rezerwacje.Where(e => e.IDClient == usserr.IDClient).ToList();

                    ViewBag.Lists = lista;

               


                    return View();
                }
            }
            else
            {
                return NotFound("user not found");
            }
        }


        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(string username, string password, string imie, string nazwisko, string adres)
        {
            var userReg = new Client { Username = username, Password = password, Imie = imie, Nazwisko = nazwisko, Adress = adres,Roles="Admin" };
            db.Clients.Add(userReg);
         
                db.SaveChanges();
            ViewData["Layout"] = "_Layout";
            return View("~/Views/Home/LogOn.cshtml");
            
            //catch
            //{
            //    return NotFound("user not found");
            //}
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
            //var currentUser = UserConstants.Users.FirstOrDefault(x => x.Username.ToLower() ==
            //    userLogin.Username.ToLower() && x.Password == userLogin.Password);
            var currusers = db.Clients.ToList().FirstOrDefault(x=>x.Username.ToLower()==userLogin.Username && x.Password==userLogin.Password);
            if (currusers != null)
            {
                var currrr = new UserModel { Username = currusers.Username, Password = currusers.Password, Roles = currusers.Roles };
                return currrr;
            }
            return null;
        }
    }
}
