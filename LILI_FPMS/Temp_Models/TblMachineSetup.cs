using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblMachineSetup
    {
        public int Id { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string Capacity { get; set; }
        public string Speed { get; set; }
        public string CapacityPacking { get; set; }
        public string SpeedPacking { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public string ProductCode { get; set; }
        public long? PlantId { get; set; }
    }
}
