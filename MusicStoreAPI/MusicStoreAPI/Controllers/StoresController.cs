using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicStoreAPI.Exceptions;
using MusicStoreAPI.Models;
using MusicStoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]    // Protege a todos los metodos del controlador
    //[Authorize(Roles = "Admin")]         // Esto es un AND donde tendra que ser SuperAdmin y Admin

    //[Authorize(Roles = "SuperAdmin, Admin")]
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private IStoreService service;
        public StoresController(IStoreService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StoreModel>> GetStoreAsync(int id, bool showInstruments = false)
        {
            try
            {
                return Ok(await service.GetStoreAsync(id, showInstruments));
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
        public async Task<ActionResult<IEnumerable<StoreModel>>> GetStoresAsync(string orderBy = "id", bool showInstruments = false)
        {
            try
          {
                return Ok(await service.GetStoresAsync(orderBy, showInstruments));
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

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<StoreModel>> CreateStoreAsync([FromBody]StoreModel newStore)
        {
            var user = User;
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var store = await service.CreateStoreAsync(newStore);
                return Created($"api/stores/{store.Id}", store);
            }
            catch (BadOperationRequest ex)
            {
                return BadRequest(ex.Message);
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

        //[Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<StoreModel>> UpdateStoreAsync(int id, [FromBody]StoreModel store)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(store.Id) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(store.Name) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(store.Phone) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(store.Address) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }
                return Ok(await service.UpdateStoreAsync(id, store));
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

        //[Authorize]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteStoreAsync(int id)
        {
            try
            {
                return Ok(await service.DeleteStoreAsync(id));
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
