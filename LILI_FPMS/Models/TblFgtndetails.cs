using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LILI_FPMS.Models
{
    public partial class TblFgtndetails
    {
        public int Id { get; set; }
        public string Fgtnno { get; set; }
        public string RequisitionNo { get; set; }
        public string ProcessNo { get; set; }
        public string Qcno { get; set; }
        public decimal QcpassQty { get; set; }
        public decimal Fgtnqty { get; set; }
        public string Comments { get; set; }
        [NotMapped]
        public decimal PendingFGTNQty { get; set; }
        [NotMapped]
        public string ProductCode { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string BatchNo { get; set; }

        public TblFgtn FgtnnoNavigation { get; set; }
    }
}
