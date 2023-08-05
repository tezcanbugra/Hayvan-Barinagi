using Hayvan_Barınağı.Data;
using Hayvan_Barınağı.Models.Hayvan;
using Microsoft.EntityFrameworkCore;

namespace Hayvan_Barınağı.Repositories
{
    public class TurRepository : ITurRepository
    {
        private readonly BarinakDbContext barinakDbContext;

        public TurRepository(BarinakDbContext barinakDbContext)
        {
            this.barinakDbContext = barinakDbContext;
        }
        public async Task<IEnumerable<Tur>> GetAllAsync()
        {
            return await barinakDbContext.Turler.ToListAsync();
        }
        public async Task<Tur?> GetAsync(Guid Id)
        {
            return await barinakDbContext.Turler.FirstOrDefaultAsync(x => x.TurId == Id);

        }

        public async Task<Tur> AddAsync(Tur tur)
        {
            await barinakDbContext.Turler.AddAsync(tur);
            await barinakDbContext.SaveChangesAsync();
            return tur;
        }
        public async Task<Tur?> UpdateAsync(Tur Tur)
        {
            var existingTur = await barinakDbContext.Turler.FindAsync(Tur.TurId);
            if (existingTur != null)
            {
                existingTur.TurAdi = Tur.TurAdi;
                await barinakDbContext.SaveChangesAsync();
                return existingTur;

            }
            return null;
        }

        public async Task<Tur?> DeleteAsyncId(Guid Id)
        {
            var existingTur = await barinakDbContext.Turler.FindAsync(Id);
            if(existingTur != null)
            {
                barinakDbContext.Turler.Remove(existingTur);
                await barinakDbContext.SaveChangesAsync();
                return existingTur;
            }
            return null;
        }
        public async Task<Tur?> DeleteAsyncObject(Tur Tur)
        {
            if(Tur != null)
            {
                barinakDbContext.Turler.Remove(Tur);
                await barinakDbContext.SaveChangesAsync();
                return Tur;

            }
            return null;
        }

    }
}
