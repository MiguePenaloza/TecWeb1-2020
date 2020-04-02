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
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private ISongService service;

        public SongsController(ISongService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public ActionResult<SongModel> GetSong(int id)
        {
            try
            {
                return Ok(service.GetSong(id));
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
        public ActionResult<IEnumerable<SongModel>> GetSongs(string orderBy = "id")
        {
            try
            {
                return Ok(service.GetSongs(orderBy));
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

        [HttpPost]
        public ActionResult<SongModel> CreateSong([FromBody]SongModel song)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newSong = service.CreateSong(song);
                return Created($"api/songs/{newSong.Id}", newSong);
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
        public ActionResult<bool> DeleteSong(int id)
        {
            try
            {
                return Ok(service.DeleteSong(id));
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
        public ActionResult<bool> UpdateSong(int id, [FromBody]SongModel song)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(song.Name) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(song.Artist) && state.Value.Errors.Count > 0) 
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(song.Length) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(song.Album) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(song.Genre) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }
                return Ok(service.UpdateSong(id, song));
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
