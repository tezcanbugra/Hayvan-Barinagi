using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hayvan_Barınağı.Controllers
{
    public class AdminTurler : Controller
    {
        private BarinakDbContext _barinakDbContext;
        public AdminTurler(BarinakDbContext barinakDbContext)
        {
            _barinakDbContext = barinakDbContext;
        }


        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(TurEkleRequest RequestModel)
        {
            //Map Request Model to actual Model
            var Tur = new Tur
            {
                TurAdi = RequestModel.TurAdi,

            };

            _barinakDbContext.Turler.Add(Tur);
            _barinakDbContext.SaveChanges();

            return View("Ekle");
        }

        [HttpGet]
        public IActionResult Goster()
        {

            var list = _barinakDbContext.Turler.ToList();

            return View(tags);
        }
    }
}
