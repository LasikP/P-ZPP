using Microsoft.AspNetCore.Mvc;
using nartyy.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = System.Data.Entity.EntityState;
using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using nartyy.Migrations;

namespace nartyy.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db = new ApplicationDbContext();

        private Rezerwacja rezerwacja;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            rezerwacja = new Rezerwacja();

        }

     
        public IActionResult Index()
        {
           
            return View();
       
        }

        [Route("LogOn")]
        public IActionResult LogOn()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("Cash")]
        public IActionResult Cash()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }
        public IActionResult Company()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("Rezerwacja")]
        [Authorize]
        [HttpPost]
        
        
        public IActionResult Rezerwacja(int id, string typSprzetu, DateTime dataRezerwacji, DateTime dataZwrotu, string user)
        {
            if (typSprzetu == "narty")
            {
                var narty = db.Narty.Find(id);
                if (narty.Dostepnosc == false)
                {
                    
                    return View("~/Views/Login/Loginnn");
                }
                else
                {
                    narty.Dostepnosc = false;
                    db.Entry(narty).State = EntityState.Modified;

                    var usserr = db.Clients.FirstOrDefault(e => e.Username == user);
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "narty";
                    rezerwacja.DataOdbioru = dataRezerwacji;
                    rezerwacja.DataZwrotu = dataZwrotu;
                    rezerwacja.IDClient = usserr.IDClient;
                    db.Rezerwacje.Add(rezerwacja);
                    narty.IDRezerwacji = rezerwacja.IDSprzet;
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Rezerwacja nart zakończona pomyślnie.";



                    
                    
                    return View("~/Views/Login/Loginnn");
                }
            }
            else if (typSprzetu == "buty")
            {
                var buty = db.ButyNarciarskiee.Find(id);
                if (buty.Dostepnosc == false)
                {
                    ViewBag.ErrorMessage = "Buty niedostępne w wybranym terminie.";
                    return RedirectToAction("Index");
                }
                else
                {
                    buty.Dostepnosc = false;
                    db.Entry(buty).State = (System.Data.Entity.EntityState)EntityState.Modified;

                    Rezerwacja rezerwacja = new Rezerwacja();
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "narty";
                  //  rezerwacja.DataOdbioru = dataOdbioru;
                   // rezerwacja.DataZwrotu = dataZwrotu;

                    db.Rezerwacje.Add(rezerwacja);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Rezerwacja nart zakończona pomyślnie.";
                    return RedirectToAction("Index");
                }
            }
            else if (typSprzetu == "buty")
            {
                var buty = db.ButyNarciarskiee.Find(id);
                if (buty.Dostepnosc == false)
                {
                    ViewBag.ErrorMessage = "Buty niedostępne w wybranym terminie.";
                    return RedirectToAction("Index");
                }
                else
                {
                    buty.Dostepnosc = false;
                    db.Entry(buty).State = (System.Data.Entity.EntityState)EntityState.Modified;

                    Rezerwacja rezerwacja = new Rezerwacja();
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "buty";
                   // rezerwacja.DataOdbioru = dataOdbioru;
                   // rezerwacja.DataZwrotu = dataZwrotu;

                    db.Rezerwacje.Add(rezerwacja);
                    db.SaveChanges();

                    ViewBag.SuccessMessage = "Rezerwacja butów narciarskich zakończona pomyślnie.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Nieznany typ sprzętu.";
                return RedirectToAction("Index");
            }
        }



    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}