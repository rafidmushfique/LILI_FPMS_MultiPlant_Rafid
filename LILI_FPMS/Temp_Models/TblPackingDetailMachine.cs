using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblPackingDetailMachine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string MachineCode { get; set; }
        public decimal MachineHour { get; set; }
        public decimal PackMachineNoOfWorker { get; set; }
        public decimal PackMachineManHour { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
