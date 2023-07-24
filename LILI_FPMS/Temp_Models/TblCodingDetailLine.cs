using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblCodingDetailLine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string LineCode { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
