using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblPackingDetailShift
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string ShiftCode { get; set; }
        public string MachineCode { get; set; }
        public int? BreakeDownCauseId { get; set; }
        public decimal? BreakeDownTime { get; set; }

        public TblManufacturingBreakDownCause BreakeDownCause { get; set; }
        public TblProductionProcess Production { get; set; }
    }
}
