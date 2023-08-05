using Hayvan_Barınağı.Models.Hayvan;

namespace Hayvan_Barınağı.Models.ViewModels
{
    public class HayvanDuzenleRequest
    {
        public Guid HayvanId { get; set; }
        public string HayvanAdi { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }

        //Hayvan sahiplenildi mi
        public bool Sahiplenildi { get; set; }

        //admin onayı
        public bool Onay { get; set; }

        //opsiyonel açıklama
        public string? Aciklama { get; set; }

    }
}

