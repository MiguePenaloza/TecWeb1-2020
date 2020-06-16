using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerParcialAPI.Exceptions;
using PrimerParcialAPI.Models;
using PrimerParcialAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Controllers
{
    [Route("api/[controller]")]
    public class StockPurchasesController : Controller
    {
        private IStockPurchaseService service;

        public StockPurchasesController(IStockPurchaseService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<StockPurchaseModel>> GetStockPurchases()
        {
            try
            {
                return Ok(service.GetStockPurchases());
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
        public ActionResult<StockPurchaseModel> CreateStockPurchase([FromBody]StockPurchaseModel stockPurchase)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newStockPurchase = service.CreateStockPurchase(stockPurchase);
                return Created($"/api/Purchases/{newStockPurchase.Id}", newStockPurchase);
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
