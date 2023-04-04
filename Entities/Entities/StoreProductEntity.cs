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
        public int IdStore { get; set; }
        public string CodeNCM { get; set; }
        public string CodeCEST { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }


        public decimal? CostPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? Unit { get; set; }
        public int? IdGroup { get; set; }
        public int? IdSuppliers { get; set; }
        public string? CodeEAN { get; set; }
        public bool? SaleBreak { get; set; }
        public int? MinimumStock { get; set; }
        public int? MaximumStock { get; set; }
        public int? CurrentStock { get; set; }
        public int? IdTaxGroup { get; set; }
        public byte[]? Image { get; set; }
        public bool? Status { get; set; }
        public StoreEntity Store { get; set; }
        public SuppliersEntity Suppliers { get; set; }

        public void SetStatusTrue()
        {
            Status = true;
        }
        public void SetNewDateRegister()
        {
            DateRegister = DateTime.Now;
        }
        public void SetSuppliersStandard(StoreProductEntity storeproduct)
        {
            IdSuppliers = storeproduct.IdSuppliers != default ? storeproduct.IdSuppliers : 5;
        }
        public void SetEntityUpdate(StoreProductEntity storeproduct)
        {
            IdStore = storeproduct.IdStore != default ? storeproduct.IdStore : IdStore;
            CodeNCM = !string.IsNullOrWhiteSpace(storeproduct.CodeNCM) ? storeproduct.CodeNCM : CodeNCM;
            CodeCEST = !string.IsNullOrWhiteSpace(storeproduct.CodeCEST) ? storeproduct.CodeCEST : CodeCEST;
            CostPrice = storeproduct.CostPrice != default ? storeproduct.CostPrice : CostPrice;
            SalePrice = storeproduct.SalePrice != default ? storeproduct.SalePrice : SalePrice;
            Unit = storeproduct.Unit != default ? storeproduct.Unit : Unit;
            IdGroup = storeproduct.IdGroup != default ? storeproduct.IdGroup : IdGroup;
            IdSuppliers = storeproduct.IdSuppliers != default ? storeproduct.IdSuppliers : IdSuppliers;
            Description = !string.IsNullOrWhiteSpace(storeproduct.Description) ? storeproduct.Description : Description;
            CodeEAN = !string.IsNullOrWhiteSpace(storeproduct.CodeEAN) ? storeproduct.CodeEAN : CodeEAN;
            SaleBreak = storeproduct.SaleBreak != default ? storeproduct.SaleBreak : SaleBreak;
            MinimumStock = storeproduct.MinimumStock != default ? storeproduct.MinimumStock : MinimumStock;
            MaximumStock = storeproduct.MaximumStock != default ? storeproduct.MaximumStock : MaximumStock;
            CurrentStock = storeproduct.CurrentStock != default ? storeproduct.CurrentStock : CurrentStock;
            IdTaxGroup = storeproduct.IdTaxGroup != default ? storeproduct.IdTaxGroup : IdTaxGroup;
            Image = storeproduct.Image ?? Image;
            Status = storeproduct.Status != default ? storeproduct.Status : Status;
        }

    }
}
