using System;
using System.Collections.Generic;

namespace LILI_FPMS.Models
{
    public partial class TblProductionManPower
    {
        public int Id { get; set; }
        public string StaffId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string CostUnit { get; set; }
    }
}
