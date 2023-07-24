using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class BatchWiseProductWiseSummaryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Code+Batch")]
        public string CodePlusBatch { get; set; }

        [DisplayName("FG Code")]
        public string FGCode { get; set; }

        [DisplayName("FG Name")]
        public string FGName { get; set; }

        [DisplayName("Pack Sise")]
        public string PackSize { get; set; }

        [DisplayName("Batch No")]
        public string BatchNo { get; set; }

        [DisplayName("FGQuantity")]
        public decimal FGQuantity { get; set; }

        [DisplayName("RM")]
        public decimal RM { get; set; }

        [DisplayName("PM")]
        public decimal PM { get; set; }

        [DisplayName("Process Loss")]
        public decimal ProcessLoss { get; set; }

        [DisplayName("Wastage")]
        public decimal Wastage  { get; set; }

        [DisplayName("OH Cost")]
        public decimal OHCost { get; set; }

        [DisplayName("Total Consumption")]
        public decimal TotalConsumption { get; set; }

        [DisplayName("RM")]
        public decimal ActualRM { get; set; }

        [DisplayName("PM")]
        public decimal ActualPM { get; set; }

        [DisplayName("Process Loss")]
        public decimal ActualProcessLoss { get; set; }

        [DisplayName("Wastage")]
        public decimal ActualWastage { get; set; }

        [DisplayName("OH Cost")]
        public decimal ActualOHCost { get; set; }

        [DisplayName("Total Consumption")]
        public decimal ActualTotalConsumption { get; set; }

        [DisplayName("RM")]
        public decimal DifferenceRM { get; set; }

        [DisplayName("PM")]
        public decimal DifferencePM { get; set; }

        [DisplayName("Process Loss")]
        public decimal DifferenceProcessLoss { get; set; }

        [DisplayName("Wastage")]
        public decimal DifferenceWastage { get; set; }

        [DisplayName("OH Cost")]
        public decimal DifferenceOHCost { get; set; }

        [DisplayName("Total Consumption")]
        public decimal DifferenceTotalConsumption { get; set; }
    }
}