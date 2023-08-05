using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models;
using Hayvan_Barınağı.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hayvan_Barınağı.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BarinakDbContext _barinakDbContext;
 

        public HomeController(ILogger<HomeController> logger, BarinakDbContext barinakDbContext)
        {
            _logger = logger;
            _barinakDbContext = barinakDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var hayvanlar = await _barinakDbContext.Hayvanlar.ToListAsync();

            var model = new HomeViewModel
            {
                Hayvanlar = hayvanlar
            };
            return View(model);
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