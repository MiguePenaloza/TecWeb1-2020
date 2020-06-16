using MusicStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Services
{
    public interface IInstrumentService
    {
        Task<InstrumentModel> GetInstrumentAsync(int storeId, int id);
        Task<IEnumerable<InstrumentModel>> GetInstrumentsAsync(int storeId, string orderBy = "id");
        Task<InstrumentModel> CreateInstrumentAsync(int storeId, InstrumentModel newInstrument);
        Task<bool> UpdateInstrumentAsync(int storeId, int id, InstrumentModel instrument);
        Task<bool> DeleteInstrumentAsync(int storeId, int id);
    }
}
