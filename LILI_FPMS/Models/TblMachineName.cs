using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblMachineName
    {
        public int Id { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public long PlantId { get; set; }
    }
}
