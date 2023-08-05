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

            return RedirectToAction("Goster");
        }

        [HttpGet]
        [ActionName("Goster")]
        public IActionResult Goster()
        {

            var list = _barinakDbContext.Turler.ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult Duzenle(int TurId)
        {
            var tur = _barinakDbContext.Turler.FirstOrDefault(x => x.TurId == TurId);

            if (tur != null)
            {
                var TurDuzenleRequest = new TurDuzenleRequest
                {
                    TurId = tur.TurId,
                    TurAdi = tur.TurAdi
                };

                return View(TurDuzenleRequest);

            }
            else return View(new TurDuzenleRequest { TurId = 3, TurAdi = "a"});

            return View(null);
        }

        [HttpPost]
        public IActionResult Duzenle(TurDuzenleRequest RequestModel)
        {
            var TurModel = new Tur
            {
                TurId = RequestModel.TurId,
                TurAdi = RequestModel.TurAdi
            };

            var eskiTur = _barinakDbContext.Turler.Find(TurModel.TurId);

            if(eskiTur != null)
            {
                eskiTur.TurAdi = TurModel.TurAdi;
                _barinakDbContext.SaveChanges();
                return RedirectToAction("Goster");
            }

            return RedirectToAction("Duzenle",new {id = TurModel.TurId});
        }
    }
}
