using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblRmrate
    {
        public int Id { get; set; }
        public string PlantCode { get; set; }
        public string ItemCode { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public string Period { get; set; }
        public decimal ClosingCost { get; set; }
    }
}
