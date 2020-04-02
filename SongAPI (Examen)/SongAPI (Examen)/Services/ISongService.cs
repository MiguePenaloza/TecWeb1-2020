using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Services
{
    public interface ISongService
    {
        IEnumerable<SongModel> GetSongs(string orderBy = "id");
    }
}
