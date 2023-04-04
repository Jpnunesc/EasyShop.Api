using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Supplier
{
    public class SupplierUpdateInput
    {
        public int? IdSuppliers { get; set; }
        public string? NumberDocument { get; set; }
        public string? FantasyName { get; set; }
        public string? CorporateName { get; set; }
        public string? ReferenceCode { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? EmailBill { get; set; }
        public string? PostalCode { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public bool? Status { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CellNumber { get; set; }
        public string? Others { get; set; }

    }
}
