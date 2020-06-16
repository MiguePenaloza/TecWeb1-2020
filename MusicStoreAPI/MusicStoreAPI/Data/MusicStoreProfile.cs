using AutoMapper;
using MusicStoreAPI.Data.Entities;
using MusicStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Data
{
    public class MusicStoreProfile : Profile
    {
        public MusicStoreProfile()
        {
            this.CreateMap<StoreEntity, StoreModel>()
                .ReverseMap();
            this.CreateMap<InstrumentEntity, InstrumentModel>()
                .ReverseMap();
        }
    }
}
