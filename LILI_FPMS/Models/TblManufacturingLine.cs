using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblManufacturingLine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string LineCode { get; set; }
       

        public TblProductionProcess Production { get; set; }

        [NotMapped]
        public string LineName { get; set; }
    }
}
