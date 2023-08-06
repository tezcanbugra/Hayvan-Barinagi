using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hayvan_Barınağı.Controllers
{
    [Authorize(Roles = "User")]

    public class UserHayvanController : Controller
    { 
        private BarinakDbContext _barinakDbContext;
        public UserHayvanController(BarinakDbContext barinakDbContext)
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
    }
}
