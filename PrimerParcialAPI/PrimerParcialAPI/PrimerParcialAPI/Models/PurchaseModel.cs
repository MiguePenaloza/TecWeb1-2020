using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialAPI.Models
{
    public class PurchaseModel
    {
        [Required]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
    }
}
