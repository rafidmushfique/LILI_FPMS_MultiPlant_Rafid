
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblCodingDetailShift
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string ShiftCode { get; set; }
        public string MachineCode { get; set; }

        [NotMapped]
        public string MachineName { get; set; }
        public int BreakeDownCauseId { get; set; }
        public decimal BreakeDownTime { get; set; }

        [NotMapped]
        public string BreakeDownCauseName { get; set; }

        public TblManufacturingBreakDownCause BreakeDownCause { get; set; }
        public TblProductionProcess Production { get; set; }
    }
}
