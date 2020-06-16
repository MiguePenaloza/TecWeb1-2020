using MusicStoreAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data.Repository
{
    public interface IMusicStoreRepository
    {
        //Stores
        Task<StoreEntity> GetStoreAsync(int id, bool showInstruments);
        Task<IEnumerable<StoreEntity>> GetStoresAsync(string orderBy, bool showInstruments);
        void CreateStore(StoreEntity newStore);
        bool UpdateStore(StoreEntity store);
        Task<bool> DeleteStoreAsync(int id);

        //Instruments
        Task<InstrumentEntity> GetInstrumentAsync(int id);
        Task<IEnumerable<InstrumentEntity>> GetInstrumentsAsync(int storeId, string orderBy);
        void CreateInstrument(InstrumentEntity newInstrument);
        bool UpdateInstrument(InstrumentEntity instrument);
        Task<bool> DeleteInstrumentAsync(int id);


        //save changes
        Task<bool> SaveChangesAsync();
    }
}
