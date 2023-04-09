using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Inventory
{
    public class StoreProductMovementOutput
    {
        public Guid IdStoreProductMovement { get; set; }
        public Guid IdInventoryMovement { get; set; }
        public int IdStoreProduct { get; set; }
        public DateTime DateRegister { get; set; }
        public int Amount { get; set; }
        public decimal? PriceTotalItens { get; set; }
    }
}
