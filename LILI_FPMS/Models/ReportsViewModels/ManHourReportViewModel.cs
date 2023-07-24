using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class ManHourReportViewModel
    {
        public int Id { get; set; }
        [DisplayName("Requisition No.")]
        public string RequisitionNo { get; set; }

        [DisplayName("Process No.")]
        public string ProcessNo { get; set; }

        [DisplayName("Portfolio")]
        public string Portfolio { get; set; }

        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [DisplayName("Item Description")]
        public string SKUProduct { get; set; }

        [DisplayName("Pack Size")]
        public decimal PackSize { get; set; }

        [DisplayName("No Of Batch")]
        public decimal BatchNo { get; set; }

        [DisplayName("Total Production (Pcs)")]
        public decimal TotalProductionPcs { get; set; }



        [DisplayName("Standard MH RM")]
        public decimal StandardMHRM { get; set; }

        [DisplayName("Standard MH PM")]
        public decimal StandardMHPM { get; set; }

        [DisplayName("Standard MH Total")]
        public decimal StandardMHTotal { get; set; }



        [DisplayName("Actual MH RM")]
        public decimal ActualMHRM { get; set; }

        [DisplayName("Actual MH PM")]
        public decimal ActualMHPM { get; set; }

        [DisplayName("Actual MH Total")]
        public decimal ActualMHTotal { get; set; }



        [DisplayName("Variance RM")]
        public decimal VarianceRM { get; set; }

        [DisplayName("Variance PM")]
        public decimal VariancePM { get; set; }

        [DisplayName("Variance Total")]
        public decimal VarianceTotal { get; set; }



    }
}