using PrimerParcialAPI.Data.Repository;
using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public class StockPurchaseService : IStockPurchaseService
    {
        private IStoreRepository repository;

        public StockPurchaseService(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public StockPurchaseModel CreateStockPurchase(StockPurchaseModel newStockPurchase)
        {
            return repository.CreateStockPurchase(newStockPurchase);
        }

        public IEnumerable<StockPurchaseModel> GetStockPurchases()
        {
            return repository.GetStockPurchases();
        }
    }
}
