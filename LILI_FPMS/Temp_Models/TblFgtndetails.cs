using System;
using System.Collections.Generic;

namespace LILI_FPMS.Temp_Models
{
    public partial class TblFgtndetails
    {
        public int Id { get; set; }
        public string Fgtnno { get; set; }
        public string ProductCode { get; set; }
        public string RequisitionNo { get; set; }
        public string ProcessNo { get; set; }
        public string Qcno { get; set; }
        public decimal QcpassQty { get; set; }
        public decimal Fgtnqty { get; set; }
        public string Comments { get; set; }

        public TblFgtn FgtnnoNavigation { get; set; }
    }
}
