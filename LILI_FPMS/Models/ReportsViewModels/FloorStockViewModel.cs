using System.ComponentModel;

namespace LILI_IMS.Models.ReprotsViewModels
{
    public class FloorStockViewModel
    {
        public int Id { get; set; }

        [DisplayName("Plant")]
        public long PlantId { get; set; }

        [DisplayName("Period")]
        public int Period { get; set; }

        [DisplayName("Material Code")]
        public string MaterialCode { get; set; }

        [DisplayName("Material Name")]
        public string MaterialName { get; set; }

        [DisplayName("Opening")]
        public decimal Openning { get; set; }

        [DisplayName("Receive")]
        public decimal Receive { get; set; }

        [DisplayName("Consumption")]
        public decimal Consumption { get; set; }

        [DisplayName("Return")]
        public decimal Returned { get; set; }

        [DisplayName("Closing Balance")]
        public decimal ClosingBalance { get; set; }

    }
}