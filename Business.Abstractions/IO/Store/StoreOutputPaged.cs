using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Store
{
    public class StoreOutputPaged
    {
        public int TotalRecords { get; set; }
        public IEnumerable<StoreOutput> ListStoreOutput { get; set; }

    }
}
