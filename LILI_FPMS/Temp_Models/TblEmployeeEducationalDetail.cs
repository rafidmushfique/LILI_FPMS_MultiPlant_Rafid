using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblEmployeeEducationalDetail
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public int ExamId { get; set; }
        public string Result { get; set; }
        public string Comment { get; set; }

        public TblEmployee Emp { get; set; }
    }
}
