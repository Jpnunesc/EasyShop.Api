using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Store
{
    public class StoreInsertInput
    {
        public int? IdStore { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateRegister { get; set; }
        public IFormFile? Image { get; set; }
        public int? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public long? PhoneNumber { get; set; }
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
