using Hayvan_Barınağı.Models.Hayvan;

namespace Hayvan_Barınağı.Models.ViewModels
{
    public class HomeViewModel : Hayvan.Hayvan
    {
        public IEnumerable<Hayvan.Hayvan> Hayvanlar { get; set; }

    }
}
