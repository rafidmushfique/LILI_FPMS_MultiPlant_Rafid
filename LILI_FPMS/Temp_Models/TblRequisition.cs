using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblRequisition
    {
        public TblRequisition()
        {
            TblRequisitionDetail = new HashSet<TblRequisitionDetail>();
            TblReturn = new HashSet<TblReturn>();
        }

        public int Id { get; set; }
        public string RequisitionNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string BusinessCode { get; set; }
        public string BatchNo { get; set; }
        public decimal NumberOfBatch { get; set; }
        public string ProductCode { get; set; }
        public string Comments { get; set; }
        public string ExtOfRequisitionNo { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public string IssueStatus { get; set; }
        public long? Bomid { get; set; }
        public long? PlantId { get; set; }

        public ICollection<TblRequisitionDetail> TblRequisitionDetail { get; set; }
        public ICollection<TblReturn> TblReturn { get; set; }
    }
}
