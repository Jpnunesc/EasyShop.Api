using Business.Abstractions.IO.CoreResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.Inventory
{
    public class InventoryMovementFilter : FilterPag
    {
        public int? IdStore { get; set; }
        public DateTime? DateRegisterInit { get; set; }
        public DateTime? DateRegisterFinish { get; set; }
        public long? NumberDocumentation { get; set; }
        public int? MovementType { get; set; }
    }
}
