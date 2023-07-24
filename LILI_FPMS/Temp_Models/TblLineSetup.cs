using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblLineSetup
    {
        public int Id { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }
        public string Comments { get; set; }
        public string Iuser { get; set; }
        public string Euser { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Edate { get; set; }
        public long? PlantId { get; set; }
    }
}
