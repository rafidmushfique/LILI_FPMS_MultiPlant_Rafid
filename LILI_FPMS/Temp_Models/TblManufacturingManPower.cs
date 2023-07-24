using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblManufacturingManPower
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string StaffId { get; set; }
        public string SectionCode { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
