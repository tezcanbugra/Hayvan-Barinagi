using Hayvan_Barınağı.Models.Hayvan;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hayvan_Barınağı.Models.ViewModels
{
    public class HayvanEkleRequest
    {

        public string HayvanAdi { get; set; }



        public int Yas { get; set; }
        public string Cinsiyet { get; set; }

        //Hayvan sahiplenildi mi
        public bool Sahiplenildi { get; set; }

        //admin onayı
        public bool Onay { get; set; }

        //opsiyonel açıklama
        public string? Aciklama { get; set; }
        public IEnumerable<SelectListItem> Turler { get; set; }
        public IEnumerable<SelectListItem> Cinsler { get; set; }

        public string SecilenTur { get; set; }
        public string SecilenCins { get; set; }

        public DateTime EklenmeTarihi { get; set; }
    }
}
