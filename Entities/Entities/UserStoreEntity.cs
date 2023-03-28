using Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserStoreEntity : IAggregateRoot
    {
        public int IdUserStore { get; set; }
        public int IdUser { get; set; }
        public int IdStore { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Status { get; set; }
        public UserEntity User { get; set; }
        public StoreEntity Store { get; set; }
    }
}
