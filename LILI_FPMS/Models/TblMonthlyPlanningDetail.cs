using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblMonthlyPlanningDetail
    {
        public int Id { get; set; }
        public string PlanningNo { get; set; }
        public string Fgcode { get; set; }
        [NotMapped]
        public string FgName { get; set; }
        public decimal PlanQty { get; set; }
        public decimal RevisedPlanQty { get; set; }
        public string Comments { get; set; }

        public decimal ActualForecast { get; set; }
        public decimal ReviewedForecast { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal ProductionRequirement { get; set; }
        public decimal Closing { get; set; }
        public TblMonthlyPlanning PlanningNoNavigation { get; set; }
    }
}
