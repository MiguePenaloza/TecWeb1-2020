using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongAPI.Exceptions;
using SongAPI.Models;
using SongAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongAPI.Controllers
{
    [Route("api/songs/{songId}/[controller]")]
    public class VotesController : Controller
    {
        private IVoteService service;

        public VotesController(IVoteService service)
        {
            this.service = service;
        }
        [HttpGet("{id:int}")]
        public ActionResult<VoteModel> GetVote(int songId, int id)
        {
            try
            {
                return Ok(service.GetVote(songId, id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<VoteModel>> GetVotes(int songId)
        {
            try
            {
                return Ok(service.GetVotes(songId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return Created($"api/songs/{songId}/votes/{newVote.Id}", newVote);
            }
            catch (BadOperationRequest ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteVote(int songId, int id)
        {
            try
            {
                return Ok(service.DeleteVote(songId, id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<bool> UpdateVote(int songId, int id, [FromBody]VoteModel vote)
        {
            try
            {
                return Ok(service.UpdateVote(songId, id, vote));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
