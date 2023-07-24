using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblPackingDetailMachine
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public string MachineCode { get; set; }
        public decimal MachineHour { get; set; }

        [NotMapped]
        public string MachineName { get; set; }


        public decimal PackMachineNoOfWorker { get; set; }
        public decimal PackMachineManHour { get; set; }

        public TblProductionProcess Production { get; set; }
    }
}
