using System;
using System.ComponentModel;
namespace LILI_FPMS.Models.ReportsViewModels
{
    public class ConsumptionReportViewModel
    {
        public DateTime ProcessDate { get; set; }
        public string MaterialCode { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal IssueQty { get; set; }
        public decimal TotalBalance { get; set; }
        public string ProductCode { get; set; }
        public decimal TotalConsumption { get; set; }
    }
}
