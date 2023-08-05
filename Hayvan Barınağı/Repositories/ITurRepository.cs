using Hayvan_Barınağı.Models.Hayvan;

namespace Hayvan_Barınağı.Repositories
{
    public interface ITurRepository
    {
         Task<IEnumerable <Tur>> GetAllAsync();
         Task<Tur?> GetAsync(Guid Id);

         Task<Tur> AddAsync(Tur Tur);
         Task<Tur?> UpdateAsync(Tur Tur);
         Task<Tur?> DeleteAsyncId(Guid Id);
         Task<Tur?> DeleteAsyncObject(Tur Tur);

    }
}
