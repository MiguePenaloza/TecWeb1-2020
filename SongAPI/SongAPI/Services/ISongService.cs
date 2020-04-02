using SongAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Services
{
    public interface ISongService
    {
        SongModel GetSong(int id);
        IEnumerable<SongModel> GetSongs(string orderBy = "id");
        SongModel CreateSong(SongModel newSong);
        bool UpdateSong(int id, SongModel newSong); 
        bool DeleteSong(int id);
    }
}
