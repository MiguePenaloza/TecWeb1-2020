using AutoMapper;
using SongAPI.Data.Entities;
using SongAPI.Data.Repository;
using SongAPI.Exceptions;
using SongAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Services
{
    public class SongService : ISongService
    {
       
        private List<string> allowedSortValues = new List<string>() { "id", "name", "artist" };
        private ISongRepository repository;
        private readonly IMapper mapper;

        public SongService(ISongRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public SongModel CreateSong(SongModel newSong)
        {
            var songEntity = mapper.Map<SongEntity>(newSong);
            var newSongEntity = repository.CreateSong(songEntity);
            return mapper.Map<SongModel>(newSongEntity);
        }

        public bool DeleteSong(int id)
        {
            GetSong(id);
            repository.DeleteSong(id);
            return true;
        }

        public SongModel GetSong(int id)
        {
            var songEntity = repository.GetSong(id);
            if (songEntity == null)
            {
                throw new NotFoundException($"The Id: {id} does not exist");
            }
            else
            {
                return mapper.Map<SongModel>(songEntity);
            }
        }

        public IEnumerable<SongModel> GetSongs(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"Bad sort value: {orderBy} allowed values are:{String.Join(",",allowedSortValues)}");
            }
            var songEntities = repository.GetSongs(orderBy);
            return mapper.Map<IEnumerable<SongModel>>(songEntities);
        }

        public bool UpdateSong(int id, SongModel newSong)
        {
            var songToUpdate = GetSong(id);
            newSong.Id = id;

            repository.UpdateSong(mapper.Map<SongEntity>(newSong));
            return true;
        }
    }
}
