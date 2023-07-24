using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblMaintenanceInformation
    {
        public int Id { get; set; }
        public string MaintenanceCode { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public decimal? MaintenanceHour { get; set; }
        public string MaintenanceName { get; set; }
        public string Description { get; set; }
        public string MaintenanceType { get; set; }
        public string MachineCode { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime? Idate { get; set; }
        public DateTime? Edate { get; set; }
    }
}
