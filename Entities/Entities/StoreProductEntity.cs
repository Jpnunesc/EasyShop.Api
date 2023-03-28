using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class StoreProductEntity : IAggregateRoot
    {
        public int IdStoreProduct { get; set; }
        public int IdProduct { get; set; }
        public int IdStore { get; set; }
        public decimal PriceOld { get; set; }
        public decimal PriceCurrent { get; set; }
        public int Unit { get; set; }
        public int IdGroup { get; set; }
        public int IdSuppliersEntity { get; set; }
        public DateTime DateRegister { get; set; }
        public int Status { get; set; }
        public ProductEntity Product { get; set; }
        public StoreEntity Store { get; set; }
        public SuppliersEntity Suppliers { get; set; }
    }
}
