using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace LILI_FPMS.Models
{
    public partial class TblRequisitionApprovalStatus
    {
        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime RequisitionStatusDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string Approver { get; set; }

        
    }
}
