
namespace Hayvan_Barınağı.Models.Hayvan
{
    public class Hayvan
    {
        public Guid HayvanId { get; set; }

        public string HayvanAdi { get; set; }
       
        //Hayvan cinsi
        public virtual Cins? Cins { get; set; }

        //Hayvan türü
        public virtual Tur? Tur { get; set; }
        
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }

        //Hayvan sahiplenildi mi
        public bool Sahiplenildi { get; set; }

        //admin onayı
        public bool Onay { get; set; }

        //opsiyonel açıklama
        public string? Aciklama { get; set; }

        public DateTime EklenmeTarihi { get; set; }
    }
}
