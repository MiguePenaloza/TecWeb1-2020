using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Data.Repository
{
    public interface IStoreRepository
    {
        ProductModel GetProduct(int id);
        IEnumerable<ProductModel> GetProducts();
        ProductModel CreateProduct(ProductModel newProduct);

        //PURCHASES
        IEnumerable<PurchaseModel> GetPurchases();
        PurchaseModel CreatePurchase(PurchaseModel newPurchase);

        bool ValidatePurchase(PurchaseModel newPurchase);

        //STOCKPURCHASES
        IEnumerable<StockPurchaseModel> GetStockPurchases();
        StockPurchaseModel CreateStockPurchase(StockPurchaseModel newStockPurchase);
    }
}
