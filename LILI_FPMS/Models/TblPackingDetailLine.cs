using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblPackingDetailLine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string LineCode { get; set; }

        [NotMapped]
        public string LineName { get; set; }


        public TblProductionProcess Production { get; set; }
    }
}
