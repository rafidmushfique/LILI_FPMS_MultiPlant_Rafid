
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LILI_FPMS.Models
{
    public partial class TblCodingDetailMachine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string MachineCode { get; set; }
        public decimal MachineHour { get; set; }

        [NotMapped]
        public string MachineName { get; set; }


        public decimal CodeMachineNoOfWorker { get; set; }
        public decimal CodeMachineManHour { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
