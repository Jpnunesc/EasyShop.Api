using Business.Abstractions.IO.CoreResult;


namespace Business.Abstractions.IO.StoreProduct
{
    public class StoreProductFilter : FilterPag
    {
        public int? IdStore { get; set; }
        public int? IdStoreProduct { get; set; }
        public string? CodeNCM { get; set; }
        public string? CodeCEST { get; set; }
        public string? CodeEAN { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
    }
}
