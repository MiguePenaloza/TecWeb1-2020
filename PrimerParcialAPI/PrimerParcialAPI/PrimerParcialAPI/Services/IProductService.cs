using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel CreateProduct(ProductModel newProduct);
    }
}
