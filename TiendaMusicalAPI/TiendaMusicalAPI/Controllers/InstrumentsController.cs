using InstrumentAPI.Exceptions;
using InstrumentAPI.Models;
using InstrumentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMusicalAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstrumentsController : Controller
    {
        private IInstrumentService service;
        public InstrumentsController(IInstrumentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstrumentModel>> getInstruments(string orderBy = "id")
        {
            try
            {
                return Ok(service.GetInstruments(orderBy));
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

        [HttpGet("{id:int}")]
        public ActionResult<InstrumentModel> GetInstrument(int id)
        {
            try
            {
                return Ok(service.GetInstrument(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<InstrumentModel> CreateInstrument([FromBody]InstrumentModel instrument)
        {
            try
            {
                var newInstrument = service.CreateInstrument(instrument);
                return Created($"/api/Instruments/{newInstrument.Id}", newInstrument);
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

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteInstrument(int id)
        {
            try
            {
                var result = service.DeleteInstrument(id);
                return Ok(result);
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
        public ActionResult<bool> UpdateInstrument(int id, [FromBody]InstrumentModel instrument)
        {
            try
            {
                return Ok(service.UpdateInstrument(id, instrument));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
