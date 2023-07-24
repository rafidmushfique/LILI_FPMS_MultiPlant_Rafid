using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblProductionProcessDetailGrn
    {
        public long Id { get; set; }
        public string ProcessNo { get; set; }
        public string MaterialCode { get; set; }
        public string Grnno { get; set; }
        public decimal ConsumeStock { get; set; }
    }
}
