using SongAPI_Examen.Data.Repository;
using SongAPI_Examen.Exceptions;
using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Services
{
    public class VoteService : IVoteService
    {
        private ISongRepository repository;
        private List<string> allowedValues = new List<string> { "id", "name" };

        public VoteService(ISongRepository repository)
        {
            this.repository = repository;
        }
        public VoteModel CreateVote(int songId, VoteModel vote)
        {
            ValidateSong(songId);
            return repository.CreateVote(songId, vote);
        }

        public VoteModel CreateVoteManager(int songId, VoteModel vote)
        {
            ValidateSong(songId);
            return repository.CreateVoteManager(songId, vote);
        }

        public IEnumerable<VoteModel> GetVotes(int songId, string orderBy = "id")
        {
            ValidateSong(songId);
            if (!allowedValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"Invalid sort value:{orderBy}, you can only sort by:{String.Join(",", allowedValues)}");
            }
            else
            {
                return repository.GetVotes(songId, orderBy);
            }
        }

        public void ValidateSong(int id)
        {
            var song = repository.GetSong(id);
            if (song == null)
            {
                throw new NotFoundException($"The song with the id:{id} does not exist");
            }
        }
    }
}
