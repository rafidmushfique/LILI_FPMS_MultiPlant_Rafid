using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblOpeningStock
    {
        public long Id { get; set; }
        public long PlantId { get; set; }
        public int Period { get; set; }
        public string MaterialCode { get; set; }
        public decimal Openning { get; set; }
        public decimal Receive { get; set; }
        public decimal Consumption { get; set; }
        public decimal Returned { get; set; }
        public decimal ClosingBalance { get; set; }
    }
}
