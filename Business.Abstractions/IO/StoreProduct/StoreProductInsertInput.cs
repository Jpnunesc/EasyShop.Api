
using Microsoft.AspNetCore.Http;


namespace Business.Abstractions.IO.StoreProduct
{
    public class StoreProductInsertInput
    {
        public int IdStoreProduct { get; set; }
        public int IdStore { get; set; }
        public string CodeNCM { get; set; }
        public string CodeCEST { get; set; }
        public string Description { get; set; }

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
        public IFormFile? Image { get; set; }
        public DateTime? DateRegister { get; set; }
        public bool? Status { get; set; }

        public byte[] ConvertIFormFileToByte()
        {
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                Image?.CopyTo(memoryStream);
                imageData = memoryStream.ToArray();
            }
            return imageData;
        }
    }
}
