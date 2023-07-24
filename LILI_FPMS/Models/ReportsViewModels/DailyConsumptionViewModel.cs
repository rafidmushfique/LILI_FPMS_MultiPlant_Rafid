using System;
using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
        public class DailyConsumptionViewModel
        {
            [DisplayName("Date")]
            public DateTime ProcessDate { get; set; }
            [DisplayName("Manufacturing Shift")]
            public string ManufacturingShift { get; set; }
            [DisplayName("Coding Detail Shift")]
            public string CodingDetailShift { get; set; }
            [DisplayName("Packing Deatial Shift")]
            public string PackingDeatialShift { get; set; }
            [DisplayName("Requsition No.")]
            public string RequisitionNo { get; set; }  
            [DisplayName("Process No.")]
            public string ProcessNo { get; set; }
            [DisplayName("Name of FG")]
            public string FGName { get; set; }
            [DisplayName("Item Code")]
            public string MaterialCode { get; set; }
            [DisplayName("Item Name")]
            public string MaterialName { get; set; }
            [DisplayName("UM")]
            public string BaseUnit { get; set; }
            [DisplayName("Nominal Quantity")]
            public decimal StdConsumptionQty { get; set; }
            [DisplayName("Opening Stock")]
            public decimal OpeningStock { get; set; }
            [DisplayName("Recieve")]
            public decimal IssueQty { get; set; }
            [DisplayName("Transfer")]
            public decimal ReturnQty { get; set; }
            [DisplayName("Used Actual")]
            public decimal TotalConsumption { get; set; }
            [DisplayName("Closeing Stock")]
            public decimal ClosingStock { get; set; }
            [DisplayName("Loss/Access")]
            public decimal LossAccess { get; set; }
            [DisplayName("Yield%")]
            public decimal Yield { get; set; }
 
        }
}

