using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblQcdetails
    {
        public int Id { get; set; }
        public string Qcno { get; set; }
        public string QcparameterCode { get; set; }
        public string QcparameterActualValue { get; set; }
        public string Comments { get; set; }

        public TblQc QcnoNavigation { get; set; }
    }
}
