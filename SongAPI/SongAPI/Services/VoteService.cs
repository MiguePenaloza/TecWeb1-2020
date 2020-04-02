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
    public class VoteService : IVoteService
    {
        private ISongRepository repository;
        private readonly IMapper mapper;

        public VoteService(ISongRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public VoteModel CreateVote(int songId, VoteModel newVote)
        {
            ValidateSong(songId);
            var voteEntity = repository.CreateVote(mapper.Map<VoteEntity>(newVote));
            return mapper.Map<VoteModel>(voteEntity);
        }

        public bool DeleteVote(int songId, int id)
        {
            var vote = GetVote(songId, id);
            if (vote == null)
            {
                throw new NotFoundException($"The Vote: {id} does not exist in the songId: {songId}");
            }
            return repository.DeleteVote(vote.Id);
        }

        public VoteModel GetVote(int songId, int id)
        {
            ValidateSong(songId);
            var vote = repository.GetVote(id);
            if (vote == null || vote.SongId != songId)
            {
                throw new NotFoundException($"The Id: {id} does not exist for the vote");
            }
            return mapper.Map<VoteModel>(vote);
        }

        public IEnumerable<VoteModel> GetVotes(int songId)
        {
            ValidateSong(songId);
            return mapper.Map<IEnumerable<VoteModel>>(repository.GetVotes(songId));
        }

        public bool UpdateVote(int songId, int id, VoteModel newVote)
        {
            var vote = GetVote(songId, id);
            newVote.Id = id;
            if (vote == null)
            {
                throw new NotFoundException($"The Id: {id} does not exist");
            }
            return repository.UpdateVote(mapper.Map<VoteEntity>(newVote));
        }

        private void ValidateSong(int id)
        {
            var songEntity = repository.GetSong(id);
            if (songEntity == null)
            {
                throw new NotFoundException($"The Id: {id} does not exist");
            }
        }

    }
}
