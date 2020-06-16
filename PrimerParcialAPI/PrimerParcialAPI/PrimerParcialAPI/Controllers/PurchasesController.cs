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
    public class PurchasesController : Controller
    {
        private IPurchaseService service;

        public PurchasesController(IPurchaseService service)
        {
            this.service = service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PurchaseModel>> GetPurchases()
        {
            try
            {
                return Ok(service.GetPurchases());
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
        public ActionResult<PurchaseModel> CreatePurchase([FromBody]PurchaseModel purchase)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newPurchase = service.CreatePurchase(purchase);
                return Created($"/api/Purchases/{purchase.Id}", purchase);
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
