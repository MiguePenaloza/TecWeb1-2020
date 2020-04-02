using SongAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Data.Repository
{
    public class SongRepository : ISongRepository
    {
        private List<SongEntity> songs = new List<SongEntity>();
        private List<VoteEntity> votes = new List<VoteEntity>();

        public SongRepository()
        {
            songs.Add(new SongEntity()
            {
                Id = 1,
                Name = "Shape of You",
                Artist = "Ed Sheeran",
                Genre = "Pop",
                Album = "+",
                Length = 4.13
            });

            songs.Add(new SongEntity()
            {
                Id = 2,
                Name = "What a man can do",
                Artist = "Jonas Brothers",
                Genre = "Pop",
                Album = "What a man can do",
                Length = 3.13
            });

            votes.Add(new VoteEntity()
            {
                Id = 1,
                Name = "Juan",
                Category = "Best Song",
                Year = 2019,
                SongId = 1
            });

            votes.Add(new VoteEntity()
            {
                Id = 2,
                Name = "Martha",
                Category = "Best Song",
                Year = 2019,
                SongId = 1
            });

            votes.Add(new VoteEntity()
            {
                Id = 3,
                Name = "John",
                Category = "Best Song",
                Year = 2019,
                SongId = 2
            });

            votes.Add(new VoteEntity()
            {
                Id = 4,
                Name = "Michelle",
                Category = "Best Song",
                Year = 2019,
                SongId = 2
            });
        }
        public SongEntity CreateSong(SongEntity newSong)
        {
            var newId = songs.OrderByDescending(s => s.Id).First().Id + 1;
            newSong.Id = newId;
            songs.Add(newSong);
            return newSong;
        }

        public VoteEntity CreateVote(VoteEntity newVote)
        {
            var newId = votes.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            newVote.Id = newId;
            votes.Add(newVote);
            return newVote;
        }

        public bool DeleteSong(int id)
        {
            var removeSong = GetSong(id);
            songs.Remove(removeSong);
            return true;
        }

        public bool DeleteVote(int id)
        {
            var vote = GetVote(id);
            return votes.Remove(vote);
        }

        public SongEntity GetSong(int id, bool showSongs = false)
        {
            return songs.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SongEntity> GetSongs(string orderBy, bool showSongs = false)
        {
            switch (orderBy)
            {
                case "id":
                    return songs.OrderBy(s => s.Id);
                case "name":
                    return songs.OrderBy(s => s.Name);
                case "artist":
                    return songs.OrderBy(s => s.Artist);
                default:
                    return songs;
            }
        }

        public VoteEntity GetVote(int id)
        {
            return votes.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<VoteEntity> GetVotes(int songId)
        {
            return votes.Where(s => s.SongId == songId);
        }

        public bool UpdateSong(SongEntity newSong)
        {
            var song = GetSong(newSong.Id);
            song.Name = newSong.Name ?? song.Name;
            song.Length = newSong.Length ?? song.Length;
            song.Genre = newSong.Genre ?? song.Genre;
            song.Artist = newSong.Artist ?? song.Artist;
            song.Album = newSong.Album ?? song.Album;
            return true;
        }

        public bool UpdateVote(VoteEntity newVote)
        {
            var vote = GetVote(newVote.Id);
            vote.Name = newVote.Name ?? vote.Name;
            vote.Year = newVote.Year ?? vote.Year;
            vote.Category = newVote.Category ?? vote.Category;
            return true;
        }
    }
}
