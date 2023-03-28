using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.User
{
    public class UserOutputPaged
    {
        public int TotalRecords { get; set; }
        public IEnumerable<UserOutput> ListUserOutput { get; set; }

    }
}
