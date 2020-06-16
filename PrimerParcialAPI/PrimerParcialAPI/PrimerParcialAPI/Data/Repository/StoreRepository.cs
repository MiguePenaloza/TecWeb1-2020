using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Data.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private List<ProductModel> products = new List<ProductModel>();
        private List<PurchaseModel> purchases = new List<PurchaseModel>();
        private List<StockPurchaseModel> stockPurchases = new List<StockPurchaseModel>();

        public StoreRepository()
        {
            products.Add(new ProductModel()
            {
                Id = 1,
                Name = "Nintendo Switch",
                Price = 300,
                Stock = 10
            });

            products.Add(new ProductModel()
            {
                Id = 2,
                Name = "Catan",
                Price = 20,
                Stock = 10
            });

            products.Add(new ProductModel()
            {
                Id = 3,
                Name = "Tv",
                Price = 250,
                Stock = 10
            });
        }


        public ProductModel CreateProduct(ProductModel newProduct)
        {
            var productNull = products.OrderByDescending(p => p.Id).FirstOrDefault();
            if (productNull == null)
            {
                newProduct.Id = 1;
            }
            else
            {
                var newId = products.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
                newProduct.Id = newId;
            }
            newProduct.Stock = 10;
            products.Add(newProduct);
            return newProduct;
        }

        public PurchaseModel CreatePurchase(PurchaseModel newPurchase)
        {
            var purchaseNull = purchases.OrderByDescending(p => p.Id).FirstOrDefault();
            if (purchaseNull == null)
            {
                newPurchase.Id = 1;
            }
            else
            {
                var newId = purchases.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
                newPurchase.Id = newId;
            }
            purchases.Add(newPurchase);

            var product = products.FirstOrDefault(p => p.Id == newPurchase.ProductId);
            product.Stock = product.Stock - newPurchase.Quantity;

            return newPurchase;
        }

        public StockPurchaseModel CreateStockPurchase(StockPurchaseModel newStockPurchase)
        {
            var stockPurchaseNull = stockPurchases.OrderByDescending(s => s.Id).FirstOrDefault();
            if (stockPurchaseNull == null)
            {
                newStockPurchase.Id = 1;
            }
            else
            {
                var newId = stockPurchases.OrderByDescending(s => s.Id).FirstOrDefault().Id + 1;
                newStockPurchase.Id = newId;
            }

            var amount = 0;
            var cantidad = 0;
            foreach (var item in products)
            {
                if(item.Stock!=10)
                {
                    cantidad = 10 - item.Stock;
                    amount = amount + (cantidad * item.Price);
                    item.Stock = 10;
                }
            }
            newStockPurchase.Amount = amount;
            stockPurchases.Add(newStockPurchase);
            return newStockPurchase;
        }

        public ProductModel GetProduct(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return products;
        }

        public IEnumerable<PurchaseModel> GetPurchases()
        {
            return purchases;
        }

        public IEnumerable<StockPurchaseModel> GetStockPurchases()
        {
            return stockPurchases;
        }

        public bool ValidatePurchase(PurchaseModel newPurchase)
        {
            var productAmount = GetProduct(newPurchase.ProductId).Stock;
            if (productAmount > newPurchase.Quantity) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
