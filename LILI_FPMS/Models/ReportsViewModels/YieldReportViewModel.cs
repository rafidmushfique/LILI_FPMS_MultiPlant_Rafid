using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class YieldReportViewModel
    {
        public int Id { get; set; }
        [DisplayName("Requisition No.")]
        public string RequisitionNo { get; set; }

        [DisplayName("Process No.")]
        public string ProcessNo { get; set; }

        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [DisplayName("SKU/Product")]
        public string SKUProduct { get; set; }

        [DisplayName("Pack Size")]
        public decimal PackSize { get; set; }

        [DisplayName("No Of Batch")]
        public decimal BatchNo { get; set; }


        [DisplayName("Std  Output (Pcs)")]
        public decimal StdOutputPcs { get; set; }

        [DisplayName("Act  Output (Pcs)")]
        public decimal ActOutputPcs { get; set; }

        [DisplayName("Yield%")]
        public decimal Yield { get; set; }


        [DisplayName("Std. Input/Batch")]
        public decimal StdInputBatch { get; set; }

        [DisplayName("Std. Output/Batch")]
        public decimal StdOutputBatch { get; set; }

        [DisplayName("Yield%")]
        public decimal Yield1 { get; set; }

        [DisplayName("Actual Input")]
        public decimal ActualInput { get; set; }

        [DisplayName("Actual Output")]
        public decimal ActualOutput { get; set; }

        [DisplayName("Yield%")]
        public decimal Yield2 { get; set; }

        [DisplayName("Gain/Loss(Qty)")]
        public decimal GainLoss { get; set; }

        [DisplayName("Wastage")]
        public decimal Wastage { get; set; }


    }
}