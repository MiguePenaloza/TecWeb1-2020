using SongAPI_Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Data.Repository
{
    public class SongRepository : ISongRepository
    {
        private List<SongModel> songs = new List<SongModel>();
        private List<VoteModel> votes = new List<VoteModel>();
        public SongRepository()
        {
            songs.Add(new SongModel()
            {
                Id = 1,
                Title = "Shape of You",
                Artist = "Ed Sheeran",
                AmountVotes = 0
            });

            songs.Add(new SongModel()
            {
                Id = 2,
                Title = "What A Man Gotta Do",
                Artist = "Jonas Brothers",
                AmountVotes = 0
            });

            songs.Add(new SongModel()
            {
                Id = 3,
                Title = "Believer",
                Artist = "Imagine Dragons",
                AmountVotes = 0
            });

            songs.Add(new SongModel()
            {
                Id = 4,
                Title = "Can't Hold Us",
                Artist = "Macklemore",
                AmountVotes = 0
            });
        }

        public VoteModel CreateVote(int songId, VoteModel vote)
        {
            var voteNull = votes.OrderByDescending(v => v.Id).FirstOrDefault();
            if (voteNull == null) 
            {
                vote.Id = 1;
            }
            else
            {
                var newId = votes.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                vote.Id = newId;
            }
            vote.SongId = songId;
            votes.Add(vote);

            var song = songs.FirstOrDefault(s => s.Id == songId);
            song.AmountVotes = song.AmountVotes + 1;
            return vote;
        }

        public VoteModel CreateVoteManager(int songId, VoteModel vote)
        {
            var voteNull = votes.OrderByDescending(v => v.Id).FirstOrDefault();
            if (voteNull == null)
            {
                vote.Id = 1;
            }
            else
            {
                var newId = votes.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                vote.Id = newId;
            }
            vote.SongId = songId;
            votes.Add(vote);

            var songManager = songs.FirstOrDefault(s => s.Id == songId);
            var songMaxAmountVotes = songs.OrderByDescending(s => s.AmountVotes).FirstOrDefault().AmountVotes + 1;

            songManager.AmountVotes = songMaxAmountVotes;
            return vote;
        }

        public SongModel GetSong(int id)
        {
            return songs.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SongModel> GetSongs(string orderBy)
        {
            switch (orderBy)
            {
                case "id":
                    return songs.OrderBy(s => s.Id);
                case "title":
                    return songs.OrderBy(s => s.Title);
                case "artist":
                    return songs.OrderBy(s => s.Artist);
                case "votes":
                    return songs.OrderBy(s => s.AmountVotes);
                default:
                    return songs;
            }
        }

        public IEnumerable<VoteModel> GetVotes(int songId, string orderBy)
        {
            switch (orderBy)
            {
                case "id":
                    return votes.Where(v => v.SongId == songId).OrderBy(v => v.Id);
                case "name":
                    return votes.Where(v => v.SongId == songId).OrderBy(v => v.Name);
                default:
                    return votes;
            }
        }
    }
}
