using AutoMapper;
using SongAPI.Data.Entities;
using SongAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Data
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<SongEntity, SongModel>()
                .ReverseMap();
            this.CreateMap<VoteEntity, VoteModel>()
                .ReverseMap();
        }
    }
}
