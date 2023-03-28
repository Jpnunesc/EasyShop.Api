using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Store
{
    public class StoreFilter
    {
        public int? IdStore { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateRegister { get; set; }
        public int? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PhoneNumber { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? SortOrder { get; set; }
        public string? SortField { get; set; }
    }
}
