using Microsoft.AspNetCore.Mvc;
using nartyy.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = System.Data.Entity.EntityState;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;

namespace nartyy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }
       
        public IActionResult Index()
        {
           
            return View();
       
        }

        public IActionResult LogOn()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }



        [Authorize]
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("/home/rezerwacja")]
        public ActionResult Rezerwacja(int id, string typSprzetu)
        {
            if (typSprzetu == "narty")
            {
                var narty = db.Narty.Find(id);
                if (narty.Dostepnosc == false)
                {
                    ViewBag.ErrorMessage = "Narty niedostępne w wybranym terminie.";
                    return RedirectToAction("Index");
                }
                else
                {
                    narty.Dostepnosc = false;
                    db.Entry(narty).State = EntityState.Modified;

                    Rezerwacja rezerwacja = new Rezerwacja();
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "narty";
                   // rezerwacja.DataOdbioru = dataOdbioru;
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