using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblFloorStock
    {
        public long Id { get; set; }
        public long PlantId { get; set; }
        public string RequisitionNo { get; set; }
        public string MaterialCode { get; set; }
        public string Grnno { get; set; }
        public DateTime StockDate { get; set; }
        public decimal IssueStock { get; set; }
        public decimal ConsumeStock { get; set; }
        public decimal AvailableStock { get; set; }
        public bool IsBooked { get; set; }
    }
}
