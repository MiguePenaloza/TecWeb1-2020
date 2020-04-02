using SongAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Data.Repository
{
    public interface ISongRepository
    {
        //songs
        SongEntity GetSong(int id, bool showSongs = false);
        IEnumerable<SongEntity> GetSongs(string orderBy, bool showSongs = false);
        SongEntity CreateSong(SongEntity newSong);
        bool UpdateSong(SongEntity newSong);
        bool DeleteSong(int id);

        //votes
        VoteEntity GetVote(int id);
        IEnumerable<VoteEntity> GetVotes(int songId);
        VoteEntity CreateVote(VoteEntity newVote);
        bool UpdateVote(VoteEntity newVote);
        bool DeleteVote(int id);
    }
}
