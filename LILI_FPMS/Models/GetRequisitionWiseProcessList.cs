using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class GetRequisitionWiseProcessList
    {
        public Int32 Id { get; set; }
        public string ProcessNo { get; set; }
        public decimal ProductionQty { get; set; }        
    }
}
