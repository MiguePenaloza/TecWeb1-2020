using PrimerParcialAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Services
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseModel> GetPurchases();
        PurchaseModel CreatePurchase(PurchaseModel newPurchase);

        void ValidateProduct(int id);
    }
}
