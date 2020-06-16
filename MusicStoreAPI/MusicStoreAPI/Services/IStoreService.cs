using MusicStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Services
{
    public interface IStoreService
    {
        Task<StoreModel> GetStoreAsync(int id, bool showInstruments = false);
        Task<IEnumerable<StoreModel>> GetStoresAsync(string orderBy = "id", bool showInstruments = false);
        Task<StoreModel> CreateStoreAsync(StoreModel newStore);
        Task<bool> UpdateStoreAsync(int id, StoreModel store);
        Task<bool> DeleteStoreAsync(int id);
    }
}
