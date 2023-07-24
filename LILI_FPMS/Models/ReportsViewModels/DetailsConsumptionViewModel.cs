using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class DetailsConsumptionViewModel
    {
        public int Id { get; set; }

        [DisplayName("FG Code & Batch No & Category")]
        public string FGCodeBatchNoAndCategory { get; set; }

        [DisplayName("FG Code & Batch No")]
        public string FGCodeAndBatchNo { get; set; }

        [DisplayName("FG Code")]
        public string FGCode { get; set; }

        [DisplayName("FG Name")]
        public string FGName { get; set; }

        [DisplayName("Pack Size")]
        public string PackSize { get; set; }

        [DisplayName("Batch Size")]
        public string BatchSize { get; set; }

        [DisplayName("Batch No")]
        public string BatchNo { get; set; }

        [DisplayName("Category")]
        public string Category { get; set; }

        [DisplayName("Mat. Code")]
        public string MatCode { get; set; }

        [DisplayName("Material Name")]
        public string MaterialName { get; set; }

        [DisplayName("Unit")]
        public string Unit { get; set; }

        [DisplayName("Process Loss")]
        public string ProcessLoss { get; set; }

        [DisplayName("Wastage")]
        public string Wastage { get; set; }

        [DisplayName("Total Consumption")]
        public string TotalConsumption { get; set; }

        [DisplayName("Rate")]
        public string Rate { get; set; }

        [DisplayName("Standard Value")]
        public string StandardValue { get; set; }

        [DisplayName("Used Value")]
        public string UsedValue { get; set; }

        [DisplayName("Process Loss")]
        public string ProcessLossValue { get; set; }

        [DisplayName("Wastage")]
        public string WastageValue { get; set; }

        [DisplayName("Total Consumption Value")]
        public string TotalConsumptionValue { get; set; }

        [DisplayName("Standard")]
        public string StdConsumptionQty { get; set; }

        [DisplayName("Used")]
        public string CurrentUseQty { get; set; }
    }
}