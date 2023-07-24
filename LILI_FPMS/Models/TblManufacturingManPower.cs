using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblManufacturingManPower
    {
        public int Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public int ProductionId { get; set; }
        public string StaffId { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
