using Microsoft.EntityFrameworkCore;
using MusicStoreAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data.Repository
{
    public class MusicStoreRepository : IMusicStoreRepository
    {
        private MusicStoreDbContext dbContext;

        public MusicStoreRepository(MusicStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private List<InstrumentEntity> instruments = new List<InstrumentEntity>();

        public void CreateInstrument(InstrumentEntity newInstrument)
        {
            dbContext.Entry(newInstrument.Store).State = EntityState.Unchanged;
            dbContext.Instruments.Add(newInstrument);
        }

        public void CreateStore(StoreEntity newStore)
        {
            dbContext.Stores.Add(newStore);
        }

        public async Task<bool> DeleteInstrumentAsync(int id)
        {
            var removeInstrument = await GetInstrumentAsync(id);
            dbContext.Instruments.Remove(removeInstrument);
            return true;
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            var removeStore = await GetStoreAsync(id, false);
            dbContext.Stores.Remove(removeStore);
            return true;
        }

        public async Task<InstrumentEntity> GetInstrumentAsync(int id)
        {
            IQueryable<InstrumentEntity> query = dbContext.Instruments;

            query = query.Include(i => i.Store);

            query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<InstrumentEntity>> GetInstrumentsAsync(int stroreId, string orderBy)
        {
            IQueryable<InstrumentEntity> query = dbContext.Instruments;

            query = query.Where(i => i.Store.Id == stroreId);

            query = query.Include(i => i.Store);

            switch (orderBy)
            {
                case "id":
                    query.OrderBy(i => i.Id);
                    break;
                case "name":
                    query.OrderBy(i => i.Name);
                    break;
                case "price":
                    query.OrderBy(i => i.Price);
                    break;
                case "description":
                    query.OrderBy(i => i.Description);
                    break;
                case "descriptionAndprice":
                    query.OrderBy(i => i.Description).OrderBy(i => i.Price);
                    break;
                default:
                    break;
            }
            query = query.AsNoTracking();

            return await query.ToArrayAsync(); 
        }

        public async Task<StoreEntity> GetStoreAsync(int id, bool showDishes)
        {
            IQueryable<StoreEntity> query = dbContext.Stores;

            if (showDishes)
            {
                query = query.Include(s => s.Instruments);
            }

            query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<StoreEntity>> GetStoresAsync(string orderBy, bool showInstruments)
        {
            IQueryable<StoreEntity> query = dbContext.Stores;

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(s => s.Id);
                    break;
                case "name":
                    query = query.OrderBy(s => s.Name);
                    break;
                default:
                    break;
            }

            if (showInstruments)
            {
                query = query.Include(s => s.Instruments);
            }

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
        }

        public bool UpdateInstrument(InstrumentEntity instrument)
        {
            /*var instrumentUpdate = dbContext.Instruments.FirstOrDefault(i => i.Id == instrument.Id);
            instrumentUpdate.Name = instrument.Name ?? instrumentUpdate.Name;
            instrumentUpdate.Description = instrument.Description ?? instrumentUpdate.Description;
            instrumentUpdate.Price = instrument.Price ?? instrument.Price;*/

            dbContext.Entry(instrument.Store).State = EntityState.Unchanged;
            dbContext.Instruments.Update(instrument);
            return true;
        }

        public bool UpdateStore(StoreEntity store)
        {
            /*var updateStore = dbContext.Stores.FirstOrDefault(s => s.Id == store.Id);
            updateStore.Name = store.Name ?? updateStore.Name;
            updateStore.Address = store.Address ?? updateStore.Address;
            updateStore.Phone = store.Phone ?? updateStore.Phone;*/

            dbContext.Stores.Update(store);
            return true;
        }
    }
}
