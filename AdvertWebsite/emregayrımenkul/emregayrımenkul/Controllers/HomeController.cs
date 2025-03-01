using System.Diagnostics;
using System.Threading.Tasks;
using emregayrımenkul.Models;
using emregayrımenkul.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emregayrımenkul.Controllers
{   
    public class HomeController : Controller
    {   

        private readonly IAdvertService _advertService;

        public HomeController(IAdvertService advertService)
        {
            _advertService = advertService;
        }


        //HomePages
        public IActionResult Index()
        {
            

            return View();
        }

        //About Page
        public IActionResult About()
        {
            return View();
        }


        //İlanlar
        public async Task<IActionResult> AllDetails()
        {   

            var advert =await _advertService.GetAdvertListAsync();

            return View(advert);
        }

        //Contact Page
        public IActionResult Contact()
        {   
            return View();
        }




        //Eklenicek Admin Panel kaldı ve sayfaları kaldı
        //sırayla nugetler kurduk daha sonra 
















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
