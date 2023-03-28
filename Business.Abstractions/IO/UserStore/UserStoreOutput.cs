using Business.Abstractions.IO.Store;
using Business.Abstractions.IO.User;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.UserStore
{
    public class UserStoreOutput
    {
        public int IdUserStore { get; set; }
        public int IdUser { get; set; }
        public int IdStore { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Status { get; set; }
        public UserOutput User { get; set; }
        public StoreOutput Store { get; set; }
    }
}
