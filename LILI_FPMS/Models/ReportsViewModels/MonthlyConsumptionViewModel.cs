using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class MonthlyConsumptionViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name of FG")]
        public string ProductName { get; set; }

        [DisplayName("Production Qty")]
        public string ProductionQty { get; set; }

        [DisplayName("Item Code")]
        public string MaterialCode { get; set; }

        [DisplayName("Item Name")]
        public string MaterialName { get; set; }

        [DisplayName("UM")]
        public string BaseUnit { get; set; }

        [DisplayName("Nominal Quantity")]
        public string StdConsumptionQty { get; set; }

        [DisplayName("Opening Stock")]
        public string OpeningStock { get; set; }

        [DisplayName("Receive")]
        public string IssueQty { get; set; }

        [DisplayName("Transfer")]
        public string ReturnQty { get; set; }

        [DisplayName("Used Actual")]
        public string TotalConsumption { get; set; }

        [DisplayName("Closing Stock")]
        public string ClosingStock { get; set; }

        [DisplayName("Loss/Access")]
        public string LossAccess { get; set; }

        [DisplayName("Yield %")]
        public string Yield { get; set; }

    }
}