using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public interface IStockPurchaseService
    {
        IEnumerable<StockPurchaseModel> GetStockPurchases();
        StockPurchaseModel CreateStockPurchase(StockPurchaseModel newStockPurchase);
    }
}
