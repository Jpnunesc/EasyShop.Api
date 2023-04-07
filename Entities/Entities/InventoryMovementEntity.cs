using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class InventoryMovementEntity : IAggregateRoot
    {
        public Guid IdInventoryMovement { get; set; }
        public DateTime DateRegister { get; set; }
        public long NumberDocumentation { get; set; }
        public int CodeDocumentClassification { get; set; }

        // tipo de movimento entrada ou saida
        public int MovementType { get; set; }
        public int IdSuppliers { get; set; }
        public int IdStore { get; set; }
        public decimal? TotalPriceProducts { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Increase { get; set; }
        public decimal? TotalPriceOperation { get; set; }
        public IEnumerable<StoreProductMovementEntity> StoreProductMovement { get; set; }

    }
}
