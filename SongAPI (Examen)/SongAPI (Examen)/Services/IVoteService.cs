using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Services
{
    public interface IVoteService
    {
        VoteModel CreateVote(int songId, VoteModel vote);
        IEnumerable<VoteModel> GetVotes(int songId, string orderBy = "id");

        void ValidateSong(int id);
    }
}
