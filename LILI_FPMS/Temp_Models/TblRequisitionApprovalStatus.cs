using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblRequisitionApprovalStatus
    {
        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime RequisitionStatusDate { get; set; }
        public string ApprovalStatus { get; set; }
        public string Approver { get; set; }
        public long? PlantId { get; set; }
    }
}
