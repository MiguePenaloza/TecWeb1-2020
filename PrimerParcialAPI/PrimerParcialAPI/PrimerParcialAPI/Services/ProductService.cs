using PrimerParcialAPI.Data.Repository;
using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public class ProductService : IProductService
    {
        private IStoreRepository repository;

        public ProductService(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public ProductModel CreateProduct(ProductModel newProduct)
        {
            return repository.CreateProduct(newProduct);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return repository.GetProducts();
        }
    }
}
