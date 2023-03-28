using Business.Abstractions.IO.CoreResult;


namespace Business.Abstractions.IO.Product
{
    public class ProductFilter : FilterPag
    {
        public int? IdProduct { get; set; }
        public string? CodeNCM { get; set; }
        public string? CodeCEST { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
    }
}
