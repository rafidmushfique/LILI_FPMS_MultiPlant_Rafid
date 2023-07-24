using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class View_IssueQuantity
    {
        public long Id { get; set; }
        public string RequisitionNo { get; set; }
        public string MaterialCode { get; set; }        
        public decimal Issue_Quantity_DC { get; set; } 
        
    }
}
