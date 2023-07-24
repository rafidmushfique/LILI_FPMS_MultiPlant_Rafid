using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class GetSearchRequisitionList
    {
        public Int32 Id { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }        
    }
}
