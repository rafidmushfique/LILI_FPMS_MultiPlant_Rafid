using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblMonthlyPlanning
    {
        public TblMonthlyPlanning()
        {
            TblMonthlyPlanningDetail = new HashSet<TblMonthlyPlanningDetail>();
        }

        public int Id { get; set; }
        public string PlanningNo { get; set; }
        public int? Period { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        public ICollection<TblMonthlyPlanningDetail> TblMonthlyPlanningDetail { get; set; }
    }
}
