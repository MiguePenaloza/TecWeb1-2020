using InstrumentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstrumentAPI.Services
{
    public interface IInstrumentService
    {
        InstrumentModel GetInstrument(int id);
        IEnumerable<InstrumentModel> GetInstruments(string orderBy = "id");
        InstrumentModel CreateInstrument(InstrumentModel newInstrument);
        bool UpdateInstrument(int id, InstrumentModel instrument);
        bool DeleteInstrument(int id);
    }
}
