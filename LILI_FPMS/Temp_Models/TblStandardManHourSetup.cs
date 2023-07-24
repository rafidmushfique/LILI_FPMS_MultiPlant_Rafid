using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblStandardManHourSetup
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal StdHrPerBatchRm { get; set; }
        public decimal StdManPowerPerBatchRm { get; set; }
        public decimal StdHrPerBatchPm { get; set; }
        public decimal StdManPowerPerBatchPm { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public decimal? StdManPowerPerUnitRm { get; set; }
        public decimal? StdManPowerPerUnitPm { get; set; }
    }
}
