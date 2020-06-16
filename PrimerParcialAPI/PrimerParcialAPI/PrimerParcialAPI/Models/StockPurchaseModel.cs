using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Models
{
    public class StockPurchaseModel
    {
        [Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
