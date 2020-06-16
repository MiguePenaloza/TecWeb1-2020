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
    public class InstrumentService : IInstrumentService
    {
        private IMusicStoreRepository repository;
        private readonly IMapper mapper;
        private List<string> allowedSortValues = new List<string> { "id", "name", "price" };

        public InstrumentService(IMusicStoreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<InstrumentModel> CreateInstrumentAsync(int storeId, InstrumentModel newInstrument)
        {
            await ValidateStoreAsync(storeId);
            newInstrument.StoreId = storeId;
            var instrumentEntity = mapper.Map<InstrumentEntity>(newInstrument);
            
            repository.CreateInstrument(instrumentEntity);

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return mapper.Map<InstrumentModel>(instrumentEntity);
            }
            throw new Exception("Database Exception");
        }

        public async Task<bool> DeleteInstrumentAsync(int storeId, int id)
        {
            await GetInstrumentAsync(storeId, id);
            await repository.DeleteInstrumentAsync(id);

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }
            throw new Exception("Database Exception");
        }

        public async Task<InstrumentModel> GetInstrumentAsync(int storeId, int id)
        {
            await ValidateStoreAsync(storeId);
            var instrument = await repository.GetInstrumentAsync(id);
            if (instrument == null) 
            {
                throw new NotFoundException($"The Instrument with the Id: {id} doesn't exist");
            }
            else
            {
                if (instrument.Store.Id != storeId)
                {
                    throw new NotFoundException($"The Instrument with the Id: {id} is not in the Store: {storeId}");
                }
                return mapper.Map<InstrumentModel>(instrument);
            }
        }

        public async Task<IEnumerable<InstrumentModel>> GetInstrumentsAsync(int storeId, string orderBy = "id")
        {
            await ValidateStoreAsync(storeId);
            orderBy = orderBy.ToLower();
            if (!allowedSortValues.Contains(orderBy)) 
            {
                throw new BadOperationRequest($"Bad sort value:{orderBy} allowed values are:{String.Join(",", allowedSortValues)}");
            }
            return mapper.Map<IEnumerable<InstrumentModel>>(await repository.GetInstrumentsAsync(storeId, orderBy));
        }

        public async Task<bool> UpdateInstrumentAsync(int storeId, int id, InstrumentModel instrument)
        {
            var actualInstrument = await GetInstrumentAsync(storeId, id);
            var updateInstrument = instrument;

            updateInstrument.Id = id;
            updateInstrument.StoreId = storeId;
            updateInstrument.Price = instrument.Price ?? actualInstrument.Price;
            updateInstrument.Description = instrument.Description ?? actualInstrument.Description;
            
            repository.UpdateInstrument(mapper.Map<InstrumentEntity>(instrument));
            
            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }
            throw new Exception("Database Exception");
        }

        private async Task ValidateStoreAsync(int storeId)
        {
            var store = await repository.GetStoreAsync(storeId, false);
            if (store == null)
            {
                throw new NotFoundException($"The Store with the Id: {storeId} doesn't exist");
            }
        }
    }
}
