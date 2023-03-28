using Entities.Data;


namespace Entities.Entities
{
    public class ProductEntity : IAggregateRoot
    {
        public int IdProduct { get; set; }
        public string CodeNCM { get; set; }
        public string CodeCEST { get; set; }
        public string Name { get; set; }
        public DateTime DateRegister { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool Status { get; set; }

        public void SetStatusTrue()
        {
            Status = true;
        }
        public void SetNewDateRegister()
        {
            DateRegister = DateTime.Now;
        }
        public void SetEntityUpdate(ProductEntity product)
        {
            IdProduct = product.IdProduct != 0 ? product.IdProduct : IdProduct;
            CodeNCM = !string.IsNullOrWhiteSpace(product.CodeNCM) ? product.CodeNCM : CodeNCM;
            CodeCEST = !string.IsNullOrWhiteSpace(product.CodeCEST) ? product.CodeCEST : CodeCEST;
            Name = !string.IsNullOrWhiteSpace(product.Name) ? product.Name : Name;
            DateRegister = product.DateRegister != DateTime.MinValue ? product.DateRegister : DateRegister;
            Description = !string.IsNullOrWhiteSpace(product.Description) ? product.Description : Description;
            Image = product.Image != null ? product.Image : Image;
            Status = product.Status ? product.Status : Status;
        }
    }
}
