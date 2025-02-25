using System.Net.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Antiforgery; // Antiforgery işlemleri için gerekli olabilir
using EmreProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmreProje.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal; // ApplicationDbContext'in bulunduğu namespace'i ekleyin

namespace EmreProje.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ApplicationDbContext _context;

        // Constructor'ı güncelledik
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index ()
        {   

            return View();
        }

        public async Task<IActionResult>allAdvert(){
            return View();
        }
         public async Task<IActionResult>contact(){
            return View();
        }

        //AddAdvert

        //public async Task<IActionResult> AddAdvert(Advert model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _context.Adverts.Add(model);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }



        //    return View();
        //}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
