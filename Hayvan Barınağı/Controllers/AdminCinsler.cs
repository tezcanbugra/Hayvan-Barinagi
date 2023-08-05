using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hayvan_Barınağı.Controllers
{
    public class AdminCinsler : Controller
    {

        private BarinakDbContext _barinakDbContext;
        public AdminCinsler(BarinakDbContext barinakDbContext)
        {
            _barinakDbContext = barinakDbContext;
        }


        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(CinsEkleRequest RequestModel)
        {
            //Map Request Model to actual Model
            var cins = new Cins
            {
                CinsAdi = RequestModel.CinsAdi,

            };

            await _barinakDbContext.Cinsler.AddAsync(cins);
            await _barinakDbContext.SaveChangesAsync();

            return RedirectToAction("Goster");
        }

        [HttpGet]
        [ActionName("Goster")]
        public async Task<IActionResult> Goster()
        {

            var list = await _barinakDbContext.Cinsler.ToListAsync();

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(Guid CinsId)
        {
            var cins = await _barinakDbContext.Cinsler.FirstOrDefaultAsync(x => x.CinsId == CinsId);

            if (cins != null)
            {
                var CinsDuzenleRequest = new CinsDuzenleRequest
                {
                    CinsId = cins.CinsId,
                    CinsAdi = cins.CinsAdi
                };

                return View(CinsDuzenleRequest);

            }


            return View(null);
        }
    }
}
