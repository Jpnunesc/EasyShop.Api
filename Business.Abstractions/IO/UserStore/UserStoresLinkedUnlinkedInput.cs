using Business.Abstractions.IO.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.UserStore
{
    public class UserStoresLinkedUnlinkedInput
    {
        public IEnumerable<UserStoreInsertInput> UserStoreLinked { get; set; }
        public IEnumerable<UserStoreInsertInput> UserStoreUnlinked { get; set; }
    }
}
