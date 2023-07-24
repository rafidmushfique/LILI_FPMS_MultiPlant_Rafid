using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblQcparameter
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string QcparameterCode { get; set; }
        public string QcparameterName { get; set; }
        public string QcparameterStandardValue { get; set; }
        public string Comments { get; set; }
        public string ProductCode { get; set; }
        public long? PlantId { get; set; }
    }
}
