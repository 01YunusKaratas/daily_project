using System.Reflection;
using System.Threading.Tasks;
using emregayrımenkul.Models;
using emregayrımenkul.Repository;
using Microsoft.AspNetCore.Mvc;

namespace emregayrımenkul.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdvertService _advertService;  // buradan advertleri çektim servisleri kullanıcaz gnelde intreface baglanıyor

        public AdminController(IAdvertService advertService)
        {
                _advertService = advertService;
        }


        [HttpGet]
        public async Task<ActionResult> Dashboard()
        {
            var advert = await _advertService.GetAdvertListAsync();
            return View(advert);    // tüm ilanları getir 
        }

       [HttpGet]
        public ActionResult CreateAdvert(){
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdvert(Advert advert ,IFormFile imageFile){

            if(ModelState.IsValid){

                await _advertService.AddAdvertAsync(advert,imageFile);
                return RedirectToAction("Dashboard","Admin");
            }

            return View(advert);


        }

    }
}
