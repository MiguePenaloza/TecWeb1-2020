using Microsoft.AspNetCore.Mvc;
using SongAPI_Examen.Models;
using SongAPI_Examen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI_Examen.Controllers
{
    [Route("api/songs/{songId}/[controller]")]
    public class VotesController : Controller
    {
        private IVoteService service;
        public VotesController(IVoteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VoteModel>> GetVotes(int songId, string orderBy = "id")
        {
            try
            {
                return Ok(service.GetVotes(songId, orderBy));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult<VoteModel> CreateVote(int songId, [FromBody]VoteModel vote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newVote = service.CreateVote(songId, vote);
                return Created($"api/songs/{songId}/votes/{vote.Id}",newVote);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{manager}")]
        public ActionResult<VoteModel> CreateVoteManager(int songId, [FromBody]VoteModel vote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newVote = service.CreateVoteManager(songId, vote);
                return Created($"api/songs/{songId}/votes/{vote.Id}", newVote);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
