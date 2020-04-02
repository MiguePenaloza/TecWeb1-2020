using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Data.Repository
{
    public interface ISongRepository
    {
        SongModel GetSong(int id);
        IEnumerable<SongModel> GetSongs(string orderBy);

        //Votes
        VoteModel CreateVote(int songId, VoteModel vote);
        IEnumerable<VoteModel> GetVotes(int songId, string orderBy);

        VoteModel CreateVoteManager(int songId, VoteModel vote);

    }
}
