using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class GetFGTNPendingList
    {
        public Int32 Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Qcno { get; set; }
        public string RequisitionNo { get; set; }
        public string ProcessNo { get; set; }
        public string BatchNo { get; set; }
        public decimal QcpassQty { get; set; }
        public decimal PendingFGTNQty { get; set; }
        public decimal Fgtnqty { get; set; }
        public string Comments { get; set; }
    }
}
