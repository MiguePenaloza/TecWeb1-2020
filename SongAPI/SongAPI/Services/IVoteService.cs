using SongAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Services
{
    public interface IVoteService
    {
        VoteModel GetVote(int songId, int id);
        IEnumerable<VoteModel> GetVotes(int songId);
        VoteModel CreateVote(int songId, VoteModel newVote);
        bool UpdateVote(int songId, int id, VoteModel newVote);
        bool DeleteVote(int songId, int id);
    }
}
