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
    public class ProductsController : Controller
    {
        private IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> getProducts()
        {
            try
            {
                return Ok(service.GetProducts());
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
        public ActionResult<ProductModel> CreateProduct([FromBody]ProductModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newProduct = service.CreateProduct(product);
                return Created($"/api/Products/{newProduct.Id}", newProduct);
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
