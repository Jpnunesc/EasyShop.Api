﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Supplier
{
    public class SupplierFilter
    {
        public int? IdSuppliersEntity { get; set; }
        public string? NumberDocument { get; set; }
        public int? DocumentType { get; set; }
        public string? FantasyName { get; set; }
        public string? CorporateName { get; set; }
        public string? Email { get; set; }
        public bool? Status { get; set; }
        public string? CellNumber { get; set; }

    }
}
