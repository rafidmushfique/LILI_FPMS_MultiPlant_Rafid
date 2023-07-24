using System;
using System.Collections.Generic;

namespace LILI_IMS.Models
{
    public partial class TblMonthlyPlanning
    {
        public TblMonthlyPlanning()
        {
            TblMonthlyPlanningDetail = new List<TblMonthlyPlanningDetail>();
        }

        public int Id { get; set; }
        public string PlanningNo { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }

        public List<TblMonthlyPlanningDetail> TblMonthlyPlanningDetail { get; set; }
    }
}
