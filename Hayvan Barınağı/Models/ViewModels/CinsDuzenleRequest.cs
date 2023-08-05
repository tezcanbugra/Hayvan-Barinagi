using Hayvan_Barınağı.Models.Hayvan;

namespace Hayvan_Barınağı.Models.ViewModels
{
    public class CinsDuzenleRequest
    {
        public Guid CinsId { get; set; }
        public string CinsAdi { get; set; }

        //cinsin ait olduğu tür 
        public virtual Tur? Tur { get; set; }

    }
}
