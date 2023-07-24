using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_IMS.Models
{
    public partial class TblStandardManHourSetup
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal StdHrPerBatchRM { get; set; }
        public decimal StdManPowerPerBatchRM { get; set; }
        public decimal StdHrPerBatchPM { get; set; }
        public decimal StdManPowerPerBatchPM { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public decimal? StdManPowerPerUnitRm { get; set; }
        public decimal? StdManPowerPerUnitPm { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
    }
}
