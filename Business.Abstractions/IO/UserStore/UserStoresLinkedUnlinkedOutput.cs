using Business.Abstractions.IO.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.UserStore
{
    public class UserStoresLinkedUnlinkedOutput
    {
        public IEnumerable<StoreOutput> StoreLinked { get; set; }
        public IEnumerable<StoreOutput> StoreUnlinked { get; set; }
    }
}
