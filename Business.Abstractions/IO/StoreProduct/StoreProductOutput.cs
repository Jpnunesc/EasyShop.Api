using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.StoreProduct
{
    public class StoreProductOutput
    {
        public int IdStoreProduct { get; set; }
        public int IdStore { get; set; }
        public string CodeNCM { get; set; }
        public string CodeCEST { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Unit { get; set; }
        public int IdGroup { get; set; }
        public int IdSuppliers { get; set; }
        public string Description { get; set; }
        public string CodeEAN { get; set; }
        public bool SaleBreak { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public int CurrentStock { get; set; }
        public int IdTaxGroup { get; set; }
        public Byte[]? Image { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Status { get; set; }

        public string ImageBase64
        {
            get
            {
                if (Image == null || Image.Length == 0) return string.Empty;
                return $"data:image/png;base64,{Convert.ToBase64String(Image)}";
            }
        }
    }
}
