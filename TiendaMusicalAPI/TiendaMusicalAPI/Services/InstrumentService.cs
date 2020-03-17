using InstrumentAPI.Exceptions;
using InstrumentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstrumentAPI.Services
{
    public class InstrumentService : IInstrumentService
    {
        private List<InstrumentModel> instruments = new List<InstrumentModel>();
        private List<string> allowedSortValues = new List<string>() { "id", "name", "price" };       
        public InstrumentService()
        {
            instruments.Add(new InstrumentModel()
            {
                Id = 1,
                Name = "Guitarra Electrica",
                Price = 200.30m,
                Description = "Yamabol",
                Discount = false
            });

            instruments.Add(new InstrumentModel()
            {
                Id = 2,
                Name = "Guitarra Acustica",
                Price = 140.30m,
                Description = "Ibanez",
                Discount = false
            });
        }

        public InstrumentModel CreateInstrument(InstrumentModel newInstrument)
        {
            var newId = instruments.OrderByDescending(i => i.Id).First().Id + 1;
            newInstrument.Id = newId;
            instruments.Add(newInstrument);
            return newInstrument;
        }

        public bool DeleteInstrument(int id)
        {
            var instrumentDelete = GetInstrument(id);            
            instruments.Remove(instrumentDelete);
            return true;
        }

        public InstrumentModel GetInstrument(int id)
        {
            var instrument = instruments.FirstOrDefault(i => i.Id == id);
            if (instrument == null)
            {
                throw new NotFoundException($"The id: {id} does not exist");
            }
            else
            {
                return instrument;
            }
            
        }

        public IEnumerable<InstrumentModel> GetInstruments(string orderBy)
        {
            if(!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"Bad sort value: {orderBy} allowed values are: {String.Join(",", allowedSortValues)}");
            }

            switch (orderBy)
            {
                case "id":
                    return instruments.OrderBy(i => i.Id);
                case "name":
                    return instruments.OrderBy(i => i.Name);
                case "price":
                    return instruments.OrderBy(i => i.Price);
                default:
                    return instruments;
            }
        }

        public bool UpdateInstrument(int id, InstrumentModel instrument)
        {
            var instrumentUpdate = GetInstrument(id);
            instrumentUpdate.Name = instrument.Name ?? instrumentUpdate.Name;
            instrumentUpdate.Price = instrument.Price ?? instrumentUpdate.Price;
            instrumentUpdate.Description = instrument.Description ?? instrumentUpdate.Description;
            instrumentUpdate.Discount = instrument.Discount ?? instrumentUpdate.Discount;
            return true;
        }
    }
}
