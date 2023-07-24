using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class MonthlyProductionReportFGViewModel
    {
        public int Id { get; set; }

        [DisplayName("ProductCode")]
        public string ProductCode { get; set; }

        [DisplayName("ProductName")]
        public string ProductName { get; set; }

        [DisplayName("Unit Name")]
        public string PackSize { get; set; }

        [DisplayName("Opening Stock")]
        public string OpeningStock { get; set; }

        [DisplayName("Production Qty")]
        public string ProductionQty { get; set; }

        [DisplayName("QC Sample Qty")]
        public string QCReferenceSampleQty { get; set; }

        [DisplayName("Transfer Qty")]
        public string DespatchQty { get; set; }

        [DisplayName("Closing Stock")]
        public string ClosingStock { get; set; }

        [DisplayName("QC Hold Qty")]
        public string QCHoldQty { get; set; }
    }
}