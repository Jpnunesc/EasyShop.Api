using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Product
{
    public class ProductOutput
    {
        public int IdProduct { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public DateTime? DateRegister { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string CodeNCM { get; set; }
        public string CodeCEST { get; set; }
    }
}
