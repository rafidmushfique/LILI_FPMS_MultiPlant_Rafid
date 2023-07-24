using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeEducationalDetail = new HashSet<TblEmployeeEducationalDetail>();
            TblEmployeeExpert = new HashSet<TblEmployeeExpert>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmpId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int EmpGrade { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? JoiningDate { get; set; }

        public ICollection<TblEmployeeEducationalDetail> TblEmployeeEducationalDetail { get; set; }
        public ICollection<TblEmployeeExpert> TblEmployeeExpert { get; set; }
    }
}
