using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblEmployeeExpert
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public int ExpertiesId { get; set; }

        public TblEmployee Emp { get; set; }
    }
}
