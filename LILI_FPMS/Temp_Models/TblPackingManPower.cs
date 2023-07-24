using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblPackingManPower
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string StaffId { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
