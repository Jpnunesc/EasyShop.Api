using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.StoreProduct
{
    public class StoreProductOutputPaged
    {
        public int TotalRecords { get; set; }
        public IEnumerable<StoreProductOutput> ListStoreProductOutput { get; set; }

    }
}
