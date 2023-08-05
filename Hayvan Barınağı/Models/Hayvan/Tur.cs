namespace Hayvan_Barınağı.Models.Hayvan
{
    public class Tur
    {
        public int TurId { get; set; }
        public string TurAdi { get; set; }

        public ICollection<Cins> Cinsler { get; set; }
        public ICollection<Hayvan> Hayvanlar { get; set; }
    }
}
