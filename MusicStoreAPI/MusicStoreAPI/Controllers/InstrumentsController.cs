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
    //[Authorize]
    [Route("api/Stores/{storeId}/[controller]")]
    public class InstrumentsController : Controller
    {
        private IInstrumentService service;

        public InstrumentsController(IInstrumentService service)
        {
            this.service = service;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstrumentModel>> GetInstrumentAsync(int storeId, int id)
        {
            try
            {
                return Ok(await service.GetInstrumentAsync(storeId, id));
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
        public async Task<ActionResult<IEnumerable<InstrumentModel>>> GetInstrumentsAsync(int storeId, string orderBy = "id")
        {
            try
            {
                return Ok(await service.GetInstrumentsAsync(storeId, orderBy));
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<InstrumentModel>> CreateInstrumentAsync(int storeId, [FromBody]InstrumentModel newInstrument)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var instrument = await service.CreateInstrumentAsync(storeId, newInstrument);
                return Created($"api/stores/{storeId}/instruments/{newInstrument.Id}", instrument);
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

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateInstrumentAsync(int storeId, int id, [FromBody]InstrumentModel instrument)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(instrument.Id) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(instrument.Name) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(instrument.Description) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                        if (state.Key == nameof(instrument.Price) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }
                return Ok(await service.UpdateInstrumentAsync(storeId, id, instrument));
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

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteInstrumentAsync(int storeId, int id)
        //public ActionResult<bool> DeleteInstrument(int storeId, int id)
        {
            try
            {
                return Ok(await service.DeleteInstrumentAsync(storeId, id));
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
