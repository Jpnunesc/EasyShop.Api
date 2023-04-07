using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StoreProductMovementEntity : IAggregateRoot
    {
        public Guid IdStoreProductMovement { get; set; }
        public Guid IdInventoryMovement { get; set; }
        public int IdStoreProduct { get; set; }
        public DateTime DateRegister { get; set; }
        public int Amount { get; set; }
        public decimal? PriceTotalItens { get; set; }
        public StoreProductEntity StoreProduct { get; set; }
        public InventoryMovementEntity InventoryMovement { get; set; }
      
        public void SetNewDateRegister()
        {
            DateRegister = DateTime.Now;
        }

    }
}
