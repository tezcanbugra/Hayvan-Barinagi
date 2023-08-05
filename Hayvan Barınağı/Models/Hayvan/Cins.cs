namespace Hayvan_Barınağı.Models.Hayvan
{
    public class Cins
    {
        public int CinsId { get; set; }
        public string CinsAdi { get; set; }

        //cinsin ait olduğu tür 
        public virtual Tur? Tur { get; set; }

        public ICollection<Hayvan> Hayvanlar { get; set; }

    }
}
