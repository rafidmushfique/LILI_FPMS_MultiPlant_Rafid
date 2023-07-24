using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class ProductWiseCostingViewModel
    {
        public int Id { get; set; }

        [DisplayName("FG Code")]
        public string FGCode { get; set; }

        [DisplayName("FG Name")]
        public string FGName { get; set; }

        [DisplayName("Pack Size")]
        public string PackSize { get; set; }

        [DisplayName("Production")]
        public decimal Production { get; set; }

        [DisplayName("Total RM")]
        public decimal StandardTotalRM { get; set; }

        [DisplayName("Total PM")]
        public decimal StandardTotalPM { get; set; }

        [DisplayName("Total OH")]
        public decimal StandardTotalOH { get; set; }

        [DisplayName("RM/Unit")]
        public decimal StandardRMPerUnit { get; set; }

        [DisplayName("PM/Unit")]
        public decimal StandardPMPerUnit { get; set; }

        [DisplayName("OH/Unit")]
        public decimal StandardOHPerUnit { get; set; }

        [DisplayName("COGS")]
        public decimal StandardCOGS { get; set; }

        [DisplayName("Total RM")]
        public decimal ActualTotalRM { get; set; }

        [DisplayName("Total PM")]
        public decimal ActualTotalPM { get; set; }

        [DisplayName("Total OH")]
        public decimal ActualTotalOH { get; set; }

        [DisplayName("RM/Unit")]
        public decimal ActualRMPerUnit { get; set; }

        [DisplayName("PM/Unit")]
        public decimal ActualPMPerUnit { get; set; }

        [DisplayName("OH/Unit")]
        public decimal ActualOHPerUnit { get; set; }

        [DisplayName("COGS")]
        public decimal ActualCOGS { get; set; }

        [DisplayName("Total RM")]
        public decimal VarianceTotalRM { get; set; }

        [DisplayName("Total PM")]
        public decimal VarianceTotalPM { get; set; }

        [DisplayName("Total OH")]
        public decimal VarianceTotalOH { get; set; }

        [DisplayName("COGS")]
        public decimal VarianceCOGS { get; set; }
    }
}