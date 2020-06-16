using AutoMapper;
using MusicStoreAPI.Data.Entities;
using MusicStoreAPI.Data.Repository;
using MusicStoreAPI.Exceptions;
using MusicStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Services
{
    public class StoreService : IStoreService
    {
        private IMusicStoreRepository repository;
        private readonly IMapper mapper;

        private List<string> allowedSortValues = new List<string>() { "id", "name" };

        public StoreService(IMusicStoreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<StoreModel> CreateStoreAsync(StoreModel newStore)
        {
            var storeEntity = mapper.Map<StoreEntity>(newStore);
            repository.CreateStore(storeEntity);
            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return mapper.Map<StoreModel>(storeEntity);
            }
            throw new Exception("Database Exception");
        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            await GetStoreAsync(id);
            await repository.DeleteStoreAsync(id);

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }
            throw new Exception("Database Exception");
        }

        public async Task<StoreModel> GetStoreAsync(int id, bool showInstruments = false)
        {
            var store =await repository.GetStoreAsync(id, showInstruments);
            if(store==null)
            {
                throw new NotFoundException($"The Store with the Id: {id} doesn't exist");
            }
            else
            {
                return mapper.Map<StoreModel>(store);
            }
        }

        public async Task<IEnumerable<StoreModel>> GetStoresAsync(string orderBy = "id", bool showInstruments = false)
        {
            orderBy = orderBy.ToLower();
            if (!allowedSortValues.Contains(orderBy)) 
            {
                throw new BadOperationRequest($"Bad sort value:{orderBy} allowed values are:{String.Join(",", allowedSortValues)}");
            }
            var storeEntities = await repository.GetStoresAsync(orderBy, showInstruments);
            return mapper.Map<IEnumerable<StoreModel>>(storeEntities);
        }

        public async Task<bool> UpdateStoreAsync(int id, StoreModel store)
        {
            var actualStore = await GetStoreAsync(id);
            var updateStore = store;
            updateStore.Id = id;
            updateStore.Address = store.Address ?? actualStore.Address;
            updateStore.Phone = store.Phone ?? actualStore.Phone;

             repository.UpdateStore(mapper.Map<StoreEntity>(updateStore));

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }
            throw new Exception("Database Exception");
        }
    }
}
