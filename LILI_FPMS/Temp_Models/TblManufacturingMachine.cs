using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblManufacturingMachine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string MachineCode { get; set; }
        public decimal MachineHour { get; set; }
        public decimal ManufacMachineNoOfWorker { get; set; }
        public decimal ManufacMachineManHour { get; set; }
        public string SectionCode { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
