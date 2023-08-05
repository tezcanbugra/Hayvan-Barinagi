using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hayvan_Barınağı.Controllers
{
    public class AdminHayvanlar : Controller
    {
        private BarinakDbContext _barinakDbContext;
        public AdminHayvanlar(BarinakDbContext barinakDbContext)
        {
            _barinakDbContext = barinakDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            var turler = await _barinakDbContext.Turler.ToListAsync();
            var cinsler = await _barinakDbContext.Cinsler.ToListAsync();
           
            var model = new HayvanEkleRequest
            {
                Turler = turler.Select(x => new SelectListItem { Text = x.TurAdi, Value = x.TurId.ToString() }),
                Cinsler = cinsler.Select(x => new SelectListItem { Text = x.CinsAdi, Value = x.CinsId.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(HayvanEkleRequest RequestModel)
        {

            DateTime currentDateTime = DateTime.Now;

            //Map Request Model to actual Model
            var hayvan = new Hayvan
            {
                HayvanAdi = RequestModel.HayvanAdi,
                Yas = RequestModel.Yas,
                Cinsiyet = RequestModel.Cinsiyet,
                Sahiplenildi = RequestModel.Sahiplenildi,
                Aciklama = RequestModel.Aciklama,
                EklenmeTarihi = currentDateTime,
                Cins = await _barinakDbContext.Cinsler.FindAsync(new Guid(RequestModel.SecilenCins)),
                Tur = await _barinakDbContext.Turler.FindAsync(new Guid(RequestModel.SecilenTur))
            };

            await _barinakDbContext.Hayvanlar.AddAsync(hayvan);
            await _barinakDbContext.SaveChangesAsync();

            return RedirectToAction("Goster");
        }

        [HttpGet]
        [ActionName("Goster")]
        public async Task<IActionResult> Goster()
        {

            var list = await _barinakDbContext.Hayvanlar.ToListAsync();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(Guid HayvanId)
        {
            var hayvan = await _barinakDbContext.Hayvanlar.FirstOrDefaultAsync(x => x.HayvanId == HayvanId);

            if (hayvan != null)
            {
                var HayvanDuzenleRequest = new HayvanDuzenleRequest
                {
                    HayvanId = hayvan.HayvanId,
                    HayvanAdi = hayvan.HayvanAdi,
                    Yas = hayvan.Yas,
                    Cinsiyet = hayvan.Cinsiyet,
                    Sahiplenildi = hayvan.Sahiplenildi

                };

                return View(HayvanDuzenleRequest);

            }


            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Duzenle(HayvanDuzenleRequest RequestModel)
        {
            var HayvanModel = new Hayvan
            {
                HayvanId = RequestModel.HayvanId,
                HayvanAdi = RequestModel.HayvanAdi,
                Yas = RequestModel.Yas,
                Cinsiyet = RequestModel.Cinsiyet,
                Sahiplenildi = RequestModel.Sahiplenildi,
                Onay = RequestModel.Onay,
                Aciklama = RequestModel.Aciklama,

            };

            var eskiHayvan = await _barinakDbContext.Turler.FindAsync(HayvanModel.HayvanId);

            if (eskiHayvan != null)
            {
                eskiHayvan.TurAdi = HayvanModel.HayvanAdi;
                await _barinakDbContext.SaveChangesAsync();
                return RedirectToAction("Goster");
            }

            return RedirectToAction("Duzenle", new { id = HayvanModel.HayvanId });
        }

        [HttpPost]
        public IActionResult Sil(HayvanDuzenleRequest RequestModel)
        {
            var hayvan = _barinakDbContext.Hayvanlar.Find(RequestModel.HayvanId);

            if (hayvan != null)
            {
                _barinakDbContext.Hayvanlar.Remove(hayvan);
                _barinakDbContext.SaveChanges();
                return RedirectToAction("Goster");
            }
            return RedirectToAction("Duzenle", new { HayvanId = RequestModel.HayvanId });
        }

        [HttpGet]
        public async Task<IActionResult> Sil(Guid HayvanId)
        {
            var hayvan = await _barinakDbContext.Hayvanlar.FindAsync(HayvanId);

            if (hayvan != null)
            {
                _barinakDbContext.Hayvanlar.Remove(hayvan);
                await _barinakDbContext.SaveChangesAsync();
                return RedirectToAction("Goster");
            }
            return RedirectToAction("Duzenle", HayvanId);
        }
    }
}

