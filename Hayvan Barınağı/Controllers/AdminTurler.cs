using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Ekle(TurEkleRequest RequestModel)
        {
            //Map Request Model to actual Model
            var Tur = new Tur
            {
                TurAdi = RequestModel.TurAdi,

            };

            await _barinakDbContext.Turler.AddAsync(Tur);
            await _barinakDbContext.SaveChangesAsync();

            return RedirectToAction("Goster");
        }

        [HttpGet]
        [ActionName("Goster")]
        public async Task<IActionResult> Goster()
        {

            var list = await _barinakDbContext.Turler.ToListAsync();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(Guid TurId)
        {
            var tur = await _barinakDbContext.Turler.FirstOrDefaultAsync(x => x.TurId == TurId);

            if (tur != null)
            {
                var TurDuzenleRequest = new TurDuzenleRequest
                {
                    TurId = tur.TurId,
                    TurAdi = tur.TurAdi
                };

                return View(TurDuzenleRequest);

            }
            

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(TurDuzenleRequest RequestModel)
        {
            var TurModel = new Tur
            {
                TurId = RequestModel.TurId,
                TurAdi = RequestModel.TurAdi
            };

            var eskiTur = await _barinakDbContext.Turler.FindAsync(TurModel.TurId);

            if(eskiTur != null)
            {
                eskiTur.TurAdi = TurModel.TurAdi;
                await _barinakDbContext.SaveChangesAsync();
                return RedirectToAction("Goster");
            }

            return RedirectToAction("Duzenle",new {id = TurModel.TurId});
        }

        [HttpPost]
        public IActionResult Sil(TurDuzenleRequest RequestModel)
        {
            var Tur = _barinakDbContext.Turler.Find(RequestModel.TurId);

            if(Tur != null)
            {
                _barinakDbContext.Turler.Remove(Tur);
                _barinakDbContext.SaveChanges();
                return RedirectToAction("Goster");
            }
            return RedirectToAction("Duzenle", new { TurId = RequestModel.TurId });
        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid TurId)
        {
            var Tur = await _barinakDbContext.Turler.FindAsync(TurId);

            if (Tur != null)
            {
                _barinakDbContext.Turler.Remove(Tur);
                await _barinakDbContext.SaveChangesAsync();
                return RedirectToAction("Goster");
            }
            return RedirectToAction("Duzenle", TurId);
        }
    }
}
