using SongAPI_Examen.Data.Repository;
using SongAPI_Examen.Exceptions;
using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Services
{
    public class SongService : ISongService
    {
        private List<string> sortValues = new List<string>() { "id", "title", "artist", "votes" };
        private ISongRepository repository;
        public SongService(ISongRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<SongModel> GetSongs(string orderBy = "id")
        {
            if(!sortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest($"Invalid value to sort:{orderBy}, the allowed values are:{String.Join(",", orderBy)}");
            }
            else
            {
                return repository.GetSongs(orderBy);
            }
        }
    }
}
