using PrimerParcialAPI.Data.Repository;
using PrimerParcialAPI.Exceptions;
using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public class PurchaseService : IPurchaseService
    {
        private IStoreRepository repository;

        public PurchaseService(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public PurchaseModel CreatePurchase(PurchaseModel newPurchase)
        {
            ValidateProduct(newPurchase.ProductId);
            var purchaseState = repository.ValidatePurchase(newPurchase);
            if (purchaseState == true)
            {
                return repository.CreatePurchase(newPurchase);
            }
            else
            {
                throw new BadOperationRequest("We don't have the quantity of the product that you want to buy");
            }
        }

        public IEnumerable<PurchaseModel> GetPurchases()
        {
            return repository.GetPurchases();
        }

        public void ValidateProduct(int id)
        {
            var product = repository.GetProduct(id);
            if (product == null)
            {
                throw new NotFoundException($"The product with the Id:{id} does not exist");
            }
        }
    }
}
